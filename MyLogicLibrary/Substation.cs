namespace MySystem
{
    public class Substation
    {
        //1. Dữ liệu thô
        protected string StationName;
        protected double MaxPower;
        //2. Thuộc tính
        public double StandardVoltage { get; } = 220.0;
        //3. Hàm khởi tạo
        public Substation(string stationName, double maxPower)
        {
            StationName = stationName;
            MaxPower = maxPower;
        }
        //4. Phương thức
        public virtual void MeasurePower(double current)
        {
            double power = StandardVoltage * current;
            bool isOverloaded = power > MaxPower;
            string status = isOverloaded ? "vuot qua gioi han" : "tram van hanh on dinh";
            Console.WriteLine($"Nang luong o {StationName} la {power} W, {status}");
            if (isOverloaded)
            {
                Console.WriteLine($"Trang thai qua tai duoc ghi nhan o {StationName}");
            }
            else
            {
                Console.WriteLine($"Trang thai on dinh duoc ghi nhan o {StationName}");
            }
        }
    }
}