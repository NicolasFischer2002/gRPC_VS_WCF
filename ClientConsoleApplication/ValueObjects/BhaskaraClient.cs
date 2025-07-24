namespace ClientConsoleApplication.ValueObjects
{
    internal record BhaskaraClient
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public BhaskaraClient(double a, double b, double c)
        {
            A = a; 
            B = b; 
            C = c;
        }
    }
}