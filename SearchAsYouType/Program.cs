using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAsYouType
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
    }

    public class ProgramUI
    {
        private List<char> _charactersEntered = new List<char>();

        List<string> _data = new List<string>
        {
            "Alaska",
            "Alabama",
            "Arkansas",
            "American Samoa",
            "Arizona",
            "California",
            "Colorado",
            "Connecticut",
            "District of Columbia",
            "Delaware",
            "Florida",
            "Georgia",
            "Guam",
            "Hawaii",
            "Iowa",
            "Idaho",
            "Illinois",
            "Indiana",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Massachusetts",
            "Maryland",
            "Maine",
            "Michigan",
            "Minnesota",
            "Missouri",
            "Mississippi",
            "Montana",
            "North Carolina",
            "North Dakota",
            "Nebraska",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "Nevada",
            "New York",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania",
            "Puerto Rico",
            "Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Virginia",
            "Virgin Islands",
            "Vermont",
            "Washington",
            "Wisconsin",
            "West Virginia",
            "Wyoming"
        };

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                EnterLetter();
                var query = QueryData(_charactersEntered);
                DisplaySearchString();
                DisplayData(query);
            }

        }

        public void EnterLetter()
        {
            ConsoleKeyInfo inputLetter = Console.ReadKey();
            if (inputLetter.Key == ConsoleKey.Backspace)
            {
                if (_charactersEntered.Count == 0)
                {
                    int something = _charactersEntered.Count;
                }
                else
                    _charactersEntered.RemoveAt(_charactersEntered.Count - 1);
            }
            else
            {
                var text = inputLetter.KeyChar;
                _charactersEntered.Add(text);
            }
            Console.Clear();
        }

        public List<string> QueryData(List<char> characters)
        {
            if (characters.Count == 0)
            {
                return new List<string>();
            }
            char[] array = characters.ToArray();
            String searchText = new String(array).ToLower();

            List<string> query = _data.Where(word => word.ToLower().Contains(searchText)).ToList();

            return query;
        }

        private void DisplayData(List<string> query)
        {
            query.ForEach(word => Console.WriteLine(word));
        }

        private void DisplaySearchString()
        {
            _charactersEntered.ForEach(ch => Console.Write(ch));
            Console.WriteLine("\n");
        }
    }
}
