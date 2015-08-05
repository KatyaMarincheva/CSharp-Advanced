using System;
using System.Collections.Generic;

class NightLife
{
    static void Main()
    {
        // database
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLife = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        // input
        while (true)
        {
            string input = Console.ReadLine();
            string[] data;

            if (input != "END")
            {
                data = input
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string city = data[0];
                string venue = data[1];
                string performer = data[2];

                // in case of new city
                if (!nightLife.ContainsKey(city))
                {
                    // add performer info
                    SortedSet<string> performers = new SortedSet<string>();
                    performers.Add(performer);

                    // add venue info
                    SortedDictionary<string, SortedSet<string>> venues = new SortedDictionary<string, SortedSet<string>>();
                    venues.Add(venue, performers);

                    // add city
                    nightLife.Add(city, venues);
                }

                // in case of new venue for existing city
                else if (nightLife.ContainsKey(city))
                {
                    if (!nightLife[city].ContainsKey(venue))
                    {
                        // add performer info
                        SortedSet<string> performers = new SortedSet<string>();
                        performers.Add(performer);

                        // add venue info
                        nightLife[city].Add(venue, performers);
                    }
                    else if (nightLife[city].ContainsKey(venue))
                    {
                        // add performer, if duplicate the set will not add it
                        nightLife[city][venue].Add(performer);
                    }
                }
            }
            else
            {
                break;
            }
        }

        // printing
        foreach (var pair1 in nightLife)
        {
            Console.WriteLine(pair1.Key);
            foreach (var pair2 in pair1.Value)
            {
                Console.WriteLine("->{0}: {1}", pair2.Key, string.Join(", ", pair2.Value));
            }
        }
    }
}

