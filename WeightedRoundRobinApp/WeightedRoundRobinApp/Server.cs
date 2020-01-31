namespace WeightedRoundRobinApp
{
    /// <summary>
    /// Server Structure
    /// </summary>
    public class Server
    {
        public int CPUUsage { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int CPUThreshold { get; set; }
    }
}
