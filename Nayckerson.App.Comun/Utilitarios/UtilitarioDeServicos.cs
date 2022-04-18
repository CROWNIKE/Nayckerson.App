using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nayckerson.App.Comum.Utilitarios
{
    public static class UtilitarioDeServicos
    {
        private static IServiceCollection _servicesCollection;

        static UtilitarioDeServicos()
        {
            _servicesCollection = new ServiceCollection();
        }

        public static void ConfigureServices(Action<IServiceCollection> action)
        {
            action(_servicesCollection);
        }

        public static IServiceProvider BuildServiceProvider()
        {
            return _servicesCollection.BuildServiceProvider();
        }
    }
}
