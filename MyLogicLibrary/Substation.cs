namespace MySystem
{
    public class Substation
    {
        public string StationName { get; protected set; }
        public double MaxPower { get;  set; }
        public double StandardVoltage { get; } = 220.0;

        public Substation(string stationName, double maxPower)
        {
            StationName = stationName;
            MaxPower = maxPower;
        }
        public virtual double CalculatePower(double current)
        {
            return StandardVoltage * current;
        }
    }
}