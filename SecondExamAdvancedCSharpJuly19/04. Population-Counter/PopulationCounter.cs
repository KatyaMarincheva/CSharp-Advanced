namespace _04.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CitiesByCountry = System.Collections.Generic.Dictionary<string, PopulationCounter.CountryInfo>;

    internal class PopulationCounter
    {
        private static void Main()
        {
            string currentLine = Console.ReadLine();

            CitiesByCountry populationDatabase = new CitiesByCountry();

            while (currentLine != "report")
            {
                string[] cityCountryPolulation = currentLine.Split('|');

                string city = cityCountryPolulation[0];
                string country = cityCountryPolulation[1];
                ulong population = ulong.Parse(cityCountryPolulation[2]);

                if (!populationDatabase.ContainsKey(country))
                {
                    populationDatabase[country] = new CountryInfo(country);
                }

                populationDatabase[country].Cities.Add(new CityInfo(city, population));
                populationDatabase[country].Population += population;

                currentLine = Console.ReadLine();
            }

            var orderedCountries = populationDatabase.OrderByDescending(c => c.Value.Population);

            foreach (var item in orderedCountries)
            {
                Console.WriteLine("{0} (total population: {1})", item.Key, item.Value.Population);

                var orderedCities = item.Value.Cities.OrderByDescending(c => c.Population);

                foreach (CityInfo city in orderedCities)
                {
                    Console.WriteLine("=>{0}: {1}", city.Name, city.Population);
                }
            }
        }

        public class CityInfo
        {
            public CityInfo(string name, ulong population)
            {
                this.Name = name;
                this.Population = population;
            }

            public string Name { get; set; }

            public ulong Population { get; set; }
        }

        public class CountryInfo
        {
            public CountryInfo(string name, ulong population, List<CityInfo> cities)
            {
                this.Name = name;
                this.Population = population;
                this.Cities = cities;
            }

            public CountryInfo(string name)
                : this(name, 0, new List<CityInfo>())
            {
            }

            public string Name { get; set; }

            public ulong Population { get; set; }

            public List<CityInfo> Cities { get; set; }
        }
    }
}