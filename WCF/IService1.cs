using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCF
{    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        ResolucaoBhaskara ResolverBhaskara(Bhaskara bhaskara);
    }

    [DataContract]
    public class ResolucaoBhaskara
    {
        [DataMember]
        public bool ResolvidoComSucesso { get; private set; }
        [DataMember]
        public double[] Resolucao { get; private set; }
        [DataMember]
        public string MensagemErro { get; private set; }

        public ResolucaoBhaskara(bool resolvidoComSucesso, double[] resolucao, string mensagemErro)
        {
            ResolvidoComSucesso = resolvidoComSucesso;
            Resolucao = resolucao;
            MensagemErro = mensagemErro;
        }
    }

    [DataContract]
    public class Bhaskara
    {
        [DataMember]
        public double A { get; private set; }
        [DataMember]
        public double B { get; private set; }
        [DataMember]
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
                return Array.Empty<double>();
            }

            double sqrtDelta = Math.Sqrt(delta);
            double x1 = (-B + sqrtDelta) / (2 * A);
            double x2 = (-B - sqrtDelta) / (2 * A);

            if (delta == 0)
            {
                // Raiz única (dupla)
                return new[] { x1 };
            }

            // Duas raízes distintas
            return new[] { x1, x2 };
        }
    }
}