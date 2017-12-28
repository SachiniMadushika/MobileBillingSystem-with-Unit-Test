using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillingSystem
{
    public class Customer
    {
        String Full_Name;
        String Address;
        String Phone_Number;
        int Package_Code;
        DateTime Registered_Date;

        public Customer(string Full_Name, string Address, string Phone_Number, int Package_Code, DateTime Registered_Date)
        {
            this.Full_Name = Full_Name;
            this.Address = Address;
            this.Phone_Number = Phone_Number;
            this.Package_Code = Package_Code;
            this.Registered_Date = Registered_Date;
        }
        public string getFullName()
        {
            return Full_Name;
        }
        public string getAddress()
        {
            return Address;
        }
        public string getPhoneNumber()
        {
            return Phone_Number;
        }
        public int getPackageCode()
        {
            return Package_Code;
        }
        public DateTime getRegisteredDate()
        {
            return Registered_Date;
        }
    }
}
