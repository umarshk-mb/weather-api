namespace Weather.Model
{
    public class GetUserReuest
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Weather { get; set; }
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        public float Pressure { get; set; }
        public string Location { get; set; }
    }
}
