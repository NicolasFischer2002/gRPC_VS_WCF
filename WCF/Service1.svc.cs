using System;
using System.Threading;

namespace WCF
{
    public class Service1 : IService1
    {
        public ResolucaoBhaskara ResolverBhaskara(Bhaskara bhaskara)
        {
			try
			{
                SimularLicenciamento();
                return new ResolucaoBhaskara(true, bhaskara.Resolver(), string.Empty);
            }
			catch (Exception erro)
			{
                return new ResolucaoBhaskara(false, Array.Empty<double>(), $"{erro.Message}");
			}
        }

        private void SimularLicenciamento()
        {
            Thread.Sleep(10);
        }
    }
}