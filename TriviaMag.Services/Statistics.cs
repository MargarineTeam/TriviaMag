using System;

namespace TriviaMag.Services
{
    public class Statistics : IComparable<Statistics>
    {

        public string Name { get; set; }

        public int Games { get; set; }
        
        public decimal Percentage { get; set; }

        public int CompareTo(Statistics other)
        {
            return other.Percentage.CompareTo(this.Percentage);
        }
    }
}
