namespace Question2
{
    //question - 02
    public class Program
    {
        static void Main(string[] args)
        {
            Source s = new Source();
            //method overloading
            Console.WriteLine(s.Add(10,20,20));
            Console.WriteLine(s.Add(10.0, 20.0, 30.0));

        }
        //class source
        public class Source
        {
            //add method with 3 integer values
            public int Add(int a, int b, int c)
            {
                return a + b + c;
            }
            //add method with 3 double values
            public double Add(double a, double b, double c)
            {
                return a + b + c;
            }
                

        }

    }
}
