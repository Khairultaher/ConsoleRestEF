
using FactoryPattern;
using FactoryPattern.Banks;
using FactoryPattern.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

class Program
{
    
    static async Task Main(string[] args)
    {
        await Task.Delay(100);

        BaseBank bank = BankFactory.Create(AppConstants.Bank);
        bank.PerformEtl();

        Console.ReadLine();
    }


    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
     .ConfigureServices((hostContext, services) =>
     {
         services.AddTransient<BaseBank, AbcBank>();
         services.AddTransient<BaseBank, PqrBank>();
         services.AddTransient<BaseBank, XyzBank>();
     });
}
