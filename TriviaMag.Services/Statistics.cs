namespace TriviaMag.Services
{
    public class Statistics
    {
        private decimal historyPercentage;

        private decimal sportPercentage;

        private decimal sciencePercentage;

        private decimal entertainmentPercentage;

        private decimal artPercentage;

        public Statistics(decimal historyPercentage, decimal sportPercentage, 
            decimal sciencePercentage, decimal entertainmentPercentage,
            decimal artPercentage)
        {
            this.historyPercentage = historyPercentage;
            this.sportPercentage = sportPercentage;
            this.sciencePercentage = sciencePercentage;
            this.entertainmentPercentage = entertainmentPercentage;
            this.artPercentage = artPercentage;
        }
        
        public decimal HistoryPercentage
        {
            get { return this.historyPercentage; }
            set { this.historyPercentage = value; }
        }

        public decimal SportPercentage
        {
            get { return this.sportPercentage; }
            set { this.sportPercentage = value; }
        }

        public decimal SciencePercentage
        {
            get { return this.sciencePercentage; }
            set { this.sciencePercentage = value; }
        }

        public decimal EntertainmentPercentage
        {
            get { return this.entertainmentPercentage; }
            set { this.entertainmentPercentage = value; }
        }

        public decimal ArtPercentage
        {
            get { return this.artPercentage; }
            set { this.artPercentage = value; }
        }

    }
}
