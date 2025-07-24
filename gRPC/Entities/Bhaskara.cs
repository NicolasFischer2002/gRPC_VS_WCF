namespace gRPC.Entities
{
    public class Bhaskara
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Bhaskara(double a, double b, double c)
        {
            ValidarBhaskara(a);

            A = a;
            B = b;
            C = c;
        }

        private void ValidarBhaskara(double a)
        {
            if (a == 0)
                throw new ArgumentException("Coeficiente 'a' não pode ser zero em uma equação de 2º grau.");
        }

        private double CalcularDiscriminante()
        {
            return B * B - 4 * A * C;
        }

        public double[] Resolver()
        {
            double delta = CalcularDiscriminante();

            if (delta < 0)
            {
                // Não há raízes reais
                return [];
            }

            double sqrtDelta = Math.Sqrt(delta);
            double x1 = (-B + sqrtDelta) / (2 * A);
            double x2 = (-B - sqrtDelta) / (2 * A);

            if (delta == 0)
            {
                // Raiz única (dupla)
                return [x1];
            }

            // Duas raízes distintas
            return [x1, x2];
        }
    }
}