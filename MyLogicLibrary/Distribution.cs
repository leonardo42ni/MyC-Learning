namespace MySystem
{
    public class DistributionStation : Substation, IAlarmable, IConnectable
    {
        public DistributionStation(string stationName, double maxPower) 
            : base(stationName, maxPower) { }
        public string GetAlarmMessage(double power)
        {
            if (power == 0) return "Chưa có dòng";
            if (power > MaxPower) return "NGẮT KHẨN CẤP: Quá tải nghiêm trọng";
            if (power > MaxPower * 0.9) return "CẢNH BÁO: Sắp vượt giới hạn";
            return "Vận hành ổn định";
        }

        public void SendDataToCloud(string data)
        {
            Console.WriteLine($"[Cloud] {StationName} gửi dữ liệu: {data}");
        }

        public void TriggerAlarm(string message)
        {
            Console.WriteLine($"[ALARM] {StationName}: {message}");
        }
    }
}