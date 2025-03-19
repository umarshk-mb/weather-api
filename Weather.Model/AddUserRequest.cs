namespace Weather.Model
{
    public class AddUserRequest
    {       
        public string Weather { get; set; } 
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        public float Pressure { get; set; }
        public string Location { get; set; } 
    }
}
