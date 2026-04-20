using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySystem; 
namespace MySmartSubstation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
  
   // Gọi cái hộp linh kiện cũ của bạn ra

// Trong class MainWindow
private void btnMeasure_Click(object sender, RoutedEventArgs e)
{
    // 1. Khởi tạo đối tượng (Lấy từ logic Giai đoạn 1)
    DistributionStation station = new DistributionStation("Trạm Bách Khoa H1", 1000.0);
    
    // 2. Giả lập đo dòng điện
    double current = 4.8; // Ampe
    double power = station.StandardVoltage * current;

    // 3. Cập nhật giao diện (Đây là bước kết nối!)
    txtStationName.Text = "Trạm Bách Khoa H1";
    txtPower.Text = $"{power} W";
    
    if (power > 1000 * 0.9) {
        txtStatus.Text = "CẢNH BÁO: GẦN QUÁ TẢI!";
        txtStatus.Foreground = System.Windows.Media.Brushes.Red;
    } else {
        txtStatus.Text = "Vận hành ổn định";
        txtStatus.Foreground = System.Windows.Media.Brushes.Green;
 
    }
}
private void sldCurrent_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
{
    // Lấy giá trị từ thanh trượt
    double current = e.NewValue;
    
    // Cập nhật con số hiển thị trên màn hình
    if (txtCurrentDisplay != null) {
        txtCurrentDisplay.Text = $"{current:F1} A";
    }
}
}
