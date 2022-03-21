using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Banks
{
    public class AbcBank : BaseBank
    {
        public override void PerformEtl()
        {
            Console.WriteLine("Customer info migration is starting!");
            /*some precess here */
            Console.WriteLine("Customer info migration is done!");
        }
    }

}
