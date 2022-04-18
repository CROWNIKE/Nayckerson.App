namespace Nayckerson.App.Comum.Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class Infraestrutura
    {
        private static readonly IConfiguration configuration;

        static Infraestrutura()
        {
            configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                      .AddJsonFile("appsettings.json").Build();
        }

        public static IConfiguration GetConfiguration()
        {
            return configuration;
        }
    }
}
