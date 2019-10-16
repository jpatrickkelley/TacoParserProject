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
            if (line == null)
            {
                return null;

            }
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogInfo("Array is less than 3");
                return null;
            }
            //double.TryParse(cells[0], out double Latitude);
            //double.TryParse(cells[1], out double Longitude);
            string name = cells[2];
            if(double.TryParse(cells[0], out double Latitude) == false) 
            {
                logger.LogInfo("Latitude failed");
                return null;
            }
            if (double.TryParse(cells[1], out double Longitute) == false)
            {
                logger.LogInfo("Longitude fail");
                return null;
            }
                           
            var tacoBell1 = new TacoBell();
            tacoBell1.Name = name;
            Point Location = new Point();
            Location.Latitude = Latitude;
            Location.Longitude = Longitute;
            tacoBell1.Location = Location;
            return tacoBell1;
            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

                // Your going to need to parse your string as a `double`
                // which is similar to parsing a string as an `int`

                // You'll need to create a TacoBell class
                // that conforms to ITrackable

                // Then, you'll need an instance of the TacoBell class
                // With the name and point set correctly

                // Then, return the instance of your TacoBell class
                // Since it conforms to ITrackable
                // Do not fail if one record parsing fails, return null
                // TODO Implement
        }
    }
}