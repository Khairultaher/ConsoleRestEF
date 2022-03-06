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
            /*some precess here */
            Console.WriteLine("Customer migration is done!");
        }
    }

}
