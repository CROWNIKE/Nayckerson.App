using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nayckerson.App.Comum.Data;
using Nayckerson.App.Comum.Utilitarios;
using Nayckerson.App.Comum.Services;
using Nayckerson.App.Comum.Services.Contracts;
using System;
using System.Windows.Forms;
using Nayckerson.App.Comum.Configuration;
using Nayckerson.App.WinUI.Controllers;

namespace Nayckerson.App.WinUI
{
    static class Program
    {
        private static IServiceProvider services;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UtilitarioDeServicos.ConfigureServices(
                services =>
                    services.AddTransient<Context>()
                            .AddTransient(x => new ClienteDataGridViewController())
                            .AddScoped<IServiceCliente, ServiceCliente>()
                            .AddSingleton<ClienteForm>()
                            .AddDbContext<Context>(
                                options => 
                                    options.UseSqlServer(
                                        Infraestrutura.GetConfiguration()
                                                      .GetConnectionString("Context"))));

            services = UtilitarioDeServicos.BuildServiceProvider();
            Application.Run(services.GetService<ClienteForm>());
        }
    }
}
