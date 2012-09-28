namespace Billboards.Common.Models
{
    public class LocationModel
    {
        public string Id { get; set; }
        public string Discription { get; set; }
        public LLA Position { get; set; }
        public double PricePerDay { get; set; }
        public bool IsAvailable { get; internal set; }
        public bool InLockState { get; internal set; }
        


    }
}
