using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace CitiesDistance
{
    class Program
    {
        struct City
        {
            public string Name;
            public int cityId;
            public int Distance;
        }

        class Task3
        {
            private Dictionary<int,City> cities;
            private int id;

            public Task3()
            {
                id = 0;
                cities = new Dictionary<int, City>();
                cities.Add("Kiev".GetHashCode(), new City {Name = "Kiev", cityId = id++, Distance = 0});
                cities.Add("Borispol".GetHashCode(), new City {Name = "Borispol", cityId = id++, Distance = 38});
                cities.Add("Piryatin".GetHashCode(), new City {Name = "Piryatin", cityId = id++, Distance = 127});
                cities.Add("Lubny".GetHashCode(), new City {Name = "Lubny", cityId = id++, Distance = 47});
                cities.Add("Horol".GetHashCode(), new City {Name = "Horol", cityId = id++, Distance = 41});
                cities.Add("Reshetylivka".GetHashCode(), new City {Name = "Reshetylivka", cityId = id++, Distance = 73});
                cities.Add("Poltava".GetHashCode(), new City {Name = "Poltava", cityId = id++, Distance = 39});
                cities.Add("Chutovo".GetHashCode(), new City {Name = "Chutovo", cityId = id++, Distance = 52});
                cities.Add("Valki".GetHashCode(), new City {Name = "Valki", cityId = id++, Distance = 38});
                cities.Add("Lubotin".GetHashCode(), new City {Name = "Lubotin", cityId = id++, Distance = 37});
                cities.Add("Pisochyn".GetHashCode(), new City {Name = "Pisochyn", cityId = id++, Distance = 15});
                cities.Add("Kharkov".GetHashCode(), new City {Name = "Kharkov", cityId = id++, Distance = 11});
            }


            static void Swap<T>(ref T obj1, ref T obj2)
            {
                var temp = obj1;
                obj1 = obj2;
                obj2 = temp;
            }


            public int GetDistance(string cityFrom, string cityTo)
            {
                int res = -1;
                int from, to;
                
                try
                {
                    from = cities[cityFrom.GetHashCode()].cityId; 
                    to = cities[cityTo.GetHashCode()].cityId;     
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return res;
                }
                
                if (from > to)
                {
                    Swap(ref from, ref to);
                }

                res = cities.Where(t => t.Value.cityId > from && t.Value.cityId <= to).Sum(t => t.Value.Distance);
                
                return res;
            } 
        }



        static void Main(string[] args)
        {
            Task3 task = new Task3();
            Stopwatch time = new Stopwatch();


            time.Start();
            Console.WriteLine(task.GetDistance("Kiev", "Pisochyn"));
            time.Stop();

            Console.WriteLine($"Elapsed time: {time.Elapsed}");
        }
    }
}
