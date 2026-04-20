using System.ComponentModel;
using System.Runtime.CompilerServices;
using MySystem;

namespace MySmartSubstation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double _current;
        private string _status = "Ổn định";
        public double Current
        {
            get => _current;
            set
            {
                if (_current != value)
                {
                    _current = value;
                    OnPropertyChanged(); // Thông báo cho giao diện
                    UpdateCalculations(); // Tính toán Power khi Current đổi
                }
            }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        private void UpdateCalculations()
        {
            if (Current > 8.0) Status = "CẢNH BÁO QUÁ TẢI!";
            else Status = "Vận hành ổn định";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}