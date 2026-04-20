namespace MySystem
{
    public class DistributionStation : Substation , IAlarmable, IConnectable
    {public DistributionStation(string stationName, double maxPower) : base(stationName, maxPower)
        {
        }
        public void TriggerAlarm (string message)
        {
            Console.WriteLine($"Alarm tu {StationName}: {message}");
        }
        public void SendDataToCloud (string data)
        {
            // Implementation for sending data to cloud
            Console.WriteLine($"Data dang gui du lieu len Cloud tu {StationName}: {data}");
        }
        public override void MeasurePower(double current)
        {
        double power = StandardVoltage * current;
        bool isAlmostOverloaded = power > MaxPower * 0.9 && power <= MaxPower;  
        if (power > MaxPower)
        {
            TriggerAlarm("Nang luong vuot qua gioi han, ngat khan cap");
            SendDataToCloud($"Nang luong da vuot qua gioi han tai {StationName}: {power} W");
        }
        else if (isAlmostOverloaded)
        {
            TriggerAlarm("Nang luong sap vuot qua gioi han!");
            SendDataToCloud($"Nang luong sap vuot qua gioi han tai {StationName}: {power} W");
        }
        else
        {
            Console.WriteLine($"Trang thai on dinh duoc ghi nhan o {StationName}");
        }
    
        }
    }
}