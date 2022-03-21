
using FactoryPattern.Banks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factory
{
    // Simple Factory pattern
    public static class BankFactory
    {
        public static Dictionary<string, BaseBank> banks 
            = new Dictionary<string, BaseBank>();

        static BankFactory()
        {
            //banks.Add(Enums.Companies.AbcBank.ToString(), new AbcBank());
            //banks.Add(Enums.Companies.PqrBank.ToString(), new PqrBank());
            //banks.Add(Enums.Companies.XyzBank.ToString(), new XyzBank());
        }
        public static BaseBank Create(string name)
        {
            // Lazy Loading pattern
            if (!banks.Any())
            {
                banks.Add(Enums.Companies.AbcBank.ToString(), new AbcBank());
                banks.Add(Enums.Companies.PqrBank.ToString(), new PqrBank());
                banks.Add(Enums.Companies.XyzBank.ToString(), new XyzBank());
            }
            // RIP(replace if with polymorphism) pattern
            return banks[name];
        }

        public static BaseBank Create2(string name)
        {

            var collection = new ServiceCollection();
            collection.AddTransient<BaseBank, AbcBank>();
            collection.AddScoped<BaseBank, PqrBank>();
            collection.AddScoped<BaseBank, XyzBank>();
            
            var serviceProvider = collection.BuildServiceProvider();
            var bank = serviceProvider.GetServices<BaseBank>()
                .FirstOrDefault(w=> w.GetType().Name == name);

            return bank;
        }

    }
}
