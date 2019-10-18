namespace LoggingKata
{
 
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
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogInfo("Array is less than 3");
                return null;
            }

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
                       
        }
    }
}