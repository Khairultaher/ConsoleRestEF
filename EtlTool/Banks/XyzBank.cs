using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtlTool.Banks
{
    public class XyzBank : BaseBank
    {
        public override void PerformEtl()
        {
            Console.WriteLine("Customer migration is done!");
            Console.WriteLine("Account migration is done!");
            Console.WriteLine("Transaction migration is done!");
        }
    }
}
