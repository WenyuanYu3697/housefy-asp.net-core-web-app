public static class DeviceStatus
{
    public static ACFanStatus Fan { get; set; } = new ACFanStatus();

    public static bool AirQualityFanIsOn { get; set; } = false;
    public static bool LightIsOn { get; set; } = false;

    public class ACFanStatus
    {
        public bool IsOn { get; set; }
        public int Speed { get; set; }
    }
}
