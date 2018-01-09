using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            BillingEngine billingEngine = new BillingEngine();

            //billingEngine.AddingNewCustomer("Kamal Perera", "no 27, Elpitiya", "077-0111111", 1, new DateTime(17, 12, 23));
            //billingEngine.SetCallDetailRecords("077-0111111", "071-0000000", new TimeSpan(16, 45, 0), 240);
            //billingEngine.Generate();
            //billingEngine.CalculateSecondsToMinutes(240);
            //billingEngine.AddingTax(15 ,100);
            //billingEngine.CalculateTotalBillAmount(15, 100, 23);
            billingEngine.PeekTimeChargeCalculate(new TimeSpan(19, 58, 00), 180, true);
        }
    }
}
