using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Banks
{
    public class PqrBank : BaseBank
    {
        public override void PerformEtl()
        {
            Console.WriteLine("Customer info migration is staring!");
            /* some precess here */
            Console.WriteLine("Customer info migration is done!");
           
            Console.WriteLine("Account info migration is staring!");
            /*some precess here */
            Console.WriteLine("Account info migration is done!");
        }
    }
}
