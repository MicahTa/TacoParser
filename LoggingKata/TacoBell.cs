namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        // Set values
        public TacoBell(string name, double longitude, double latitude) {
            Name = name;
            Location = new Point(latitude, longitude);
        }
        // Setting values on creation not manditory
        public TacoBell() {}
    }
}
