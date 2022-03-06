
using FactoryPattern;
using FactoryPattern.Banks;
using FactoryPattern.Factory;
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
}
