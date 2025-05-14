namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            // Normalize Data
            var cells = line.Split(',');

            // Each Cell should have three values
            if (cells.Length < 3) {
                return null; 
            }

            // Get store infomtion
            double latitude = double.Parse(cells[0]);
            double longitude  = double.Parse(cells[1]);
            string name  = cells[2];

            // return store info
            TacoBell location = new TacoBell(name, longitude, latitude);
            return location;
        }
    }
}
