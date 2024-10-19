namespace October19Assignment
{
    //question - 01
    public class Program
    {
        static void Main(string[] args)
        {
            //creating list and initializing the list
            IList<Person> p = new List<Person>();
            p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });
            //calling methods to get specific output 
            PersonImplementation imp = new PersonImplementation();
            Console.WriteLine(imp.GetName(p));
            Console.WriteLine(imp.Average(p));
            Console.WriteLine(imp.Max(p));

        }

        // class person
        public class Person
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }

        }
        //person implementation class
        public class PersonImplementation
        {
            public string GetName(IList<Person> person)
            {
                string name = "";
                foreach(Person p in person)
                {
                    name += $"{p.Name} {p.Address}";
                }
                return name;

            }
            public double Average (IList<Person> person)
            {
                double total_age = 0;
                double count = 0;
                foreach(var i in person)
                {
                    total_age += i.Age;
                    count++;
                }
                return total_age / count;
            }
            public int Max(IList<Person> person)
            {
                int max_age = 0;
                foreach(var i in person)
                {
                    if(i.Age > max_age)
                    {
                        max_age = i.Age;
                    }
                }
                return max_age;
            }
        }
    }

}
