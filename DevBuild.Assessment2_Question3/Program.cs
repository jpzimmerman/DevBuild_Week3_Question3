using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.Assessment2_Question3
{
    class Program
    {
        static List<string> strList = new List<string>();
        static string[] menuOptions = { "Print List", "Add Items to List", "Search List", "Sort List Alphabetically", "Exit" };
        static string userResponse;
        static uint userSelection;

        static void Main(string[] args)
        {
            strList.Add("hyperbole");
            strList.Add("organ grinder");
            strList.Add("archaeopteryx");
            strList.Add("apiphobia");

            //DisplayMenuOptions();
            //PrintList(strList);

            while(true)
            {
                DisplayMenuOptions();
                while (!uint.TryParse(userResponse, out userSelection) || userSelection < 1 || userSelection > menuOptions.Length)
                {
                    userResponse = "";
                    UserInput.PromptUntilValidEntry($"Please enter a selection from 1 to {menuOptions.Length}: ", ref userResponse, InformationType.Numeric);
                }
                
                switch (userSelection)
                {
                    case 1: { PrintList(strList); break; }
                    case 2: { AddToList(strList); break; }
                    case 3: { SearchList(strList); break; }
                    case 4: { SortListAlphabetically(strList); break; }
                    case 5: { return; }
                }
                userResponse = "";
                userSelection = 0;

            }

        }

        public static void DisplayMenuOptions()
        {
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}.) {menuOptions[i]}");
            }
        }

        public static void AddToList(List<string> baseList)
        {
            string newItem = "";

            UserInput.PromptUntilValidEntry("Please enter word to add: ", ref newItem);

            if (!String.IsNullOrEmpty(newItem))
            {
                baseList.Add(newItem);
            }
        }

        public static void PrintList(List<string> listItems)
        {
            Console.WriteLine("");
            foreach (string s in listItems)
            {
                Console.WriteLine("     " + s);
            }
            Console.WriteLine("");
        }

        public static List<string> SearchList(List<string> listItems)
        {
            List<string> searchResults = new List<string>();
            string userQuery = "";

            UserInput.PromptUntilValidEntry("Please enter a search term: ", ref userQuery);

            //let's see if we can find exact matches
            searchResults = listItems.Where<string>(x => x == userQuery).ToList<string>();

            //if entire string wasn't matched, let's check for partials
            if (searchResults.Count == 0)
            {
                foreach (string s in listItems)
                {
                    if (s.Contains(userQuery))
                    {
                        searchResults.Add(s);
                    }
                }
            }
            Console.WriteLine("Search results: ");
            PrintList(searchResults);

            return searchResults;
        }

        public static void SortListAlphabetically(List<string> baseList)
        {
            baseList.Sort();
        }

    }
}
