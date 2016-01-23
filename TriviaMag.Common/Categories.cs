using System.Collections.Generic;

namespace TriviaMag.Common
{
    public class Categories
    {
        public const string History = "History";

        public const string Sport = "Sport";

        public const string Art = "Art";

        public const string Science = "Science";

        public const string Entertainment = "Entertainment";

        public ICollection<string> GetCategories()
        {
            var list = new List<string>()
            {
           "History",
           "Sport",
           "Art",
           "Science",
           "Entertainment"
            };

            return list;
        }
    }
}
