namespace LoggingKata
{
    public struct Point {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        // Set values
        public Point(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }
        // setting values on creation not manditory
        public Point() {}
    }
}
