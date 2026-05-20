using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using MySystem;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace MySmartSubstation
{
    public class MainViewModel : INotifyPropertyChanged

    {
        public ObservableCollection<string> StatusHistory { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<DistributionStation> Stations { get; set; }
        // Khởi tạo đối tượng từ Library
        private DistributionStation _station = new DistributionStation("Trạm chính", 1500.0);
        private double _current;
        public double Current
        {
            get => _current;
            set { 
                _current = value; 
                OnPropertyChanged();
                OnPropertyChanged(nameof(StationName));
                OnPropertyChanged(nameof(Power));
                OnPropertyChanged(nameof(StatusMessage));
                OnPropertyChanged(nameof(StatusColor));
            }
        }

        // Các thuộc tính để đưa lên UI
        public DistributionStation CurrentStation
        {
            get;
            set
            {
                field = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StationName));
                OnPropertyChanged(nameof(Power));
                OnPropertyChanged(nameof(StatusMessage));
                OnPropertyChanged(nameof(StatusColor));
            }
        }
        
        public string StationName => CurrentStation?.StationName ?? _station.StationName;
        
        public double Power => (CurrentStation ?? _station).CalculatePower(Current);

        public string StatusMessage => (CurrentStation ?? _station).GetAlarmMessage(Power);

        public Brush StatusColor
        {
            get
            {
                var station = CurrentStation ?? _station;
                if (Power > station.MaxPower) return Brushes.Red;
                if (Power > station.MaxPower * 0.9) return Brushes.Orange;
                return Brushes.Green;
            }
        }

        // Khai báo ICommand 
        public ICommand LogStatusCommand { get; }
        public ICommand AddStationCommand {get;}
        public ICommand IncreaseCommand { get; }
        public ICommand DecreaseCommand { get; }

    public MainViewModel()
    {
        LogStatusCommand = new RelayCommand(obj =>
        {
            string logEntry = $"{DateTime.Now}: {StationName} - Dòng: {Current:F1} A, Công suất: {Power:F1} W, Trạng thái: {StatusMessage}";
            StatusHistory.Add(logEntry);
        });
        Stations = new ObservableCollection<DistributionStation>();
        CurrentStation = _station;
        AddStationCommand = new RelayCommand( 
        execute: obj=>
        {
           if (Stations.Count < 5)
            {
            var newStation = new DistributionStation($"Trạm phụ {Stations.Count + 1}", 1500.0 + Stations.Count * 500);
            Stations.Add(newStation);
            CurrentStation = newStation;
            }
        },   
        canExecute: obj => Stations.Count < 5
        );
        IncreaseCommand = new RelayCommand(
            execute: (p) => { Current += 0.5; },
            canExecute: (p) => Current < 10.0 
        );
        DecreaseCommand = new RelayCommand(
            execute: (p) => { Current -= 0.5; },
            canExecute: (p) => Current > 0.0 
        );
    }

        //NotifyPropertyChanged 
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}