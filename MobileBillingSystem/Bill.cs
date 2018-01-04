using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillingSystem
{
    public class Bill
    {
        Customer customer;
        double totalCallCharge;
        double totalDiscount;
        double tax;
        double rental;
        double billAmount;
        List<CallDetails> callDetails = new List<CallDetails>();

        public Bill(Customer customer)
        {
            this.customer = customer;
        }
        public void SetCustomer(Customer customer)
        {
            this.customer = customer;
        }
        public void SetTotalCallCharge(double totalCallCharge)
        {
            this.totalCallCharge = totalCallCharge;
        }
        public void SetTotalDiscount(double totalDiscount)
        {
            this.totalDiscount = totalDiscount;
        }
        public void SetTax(double tax)
        {
            this.tax = tax;
        }
        public void SetRental(double rental)
        {
            this.rental = rental;
        }
        public void SetBillAmount(double billAmount)
        {
            this.billAmount = billAmount;
        }
        //public void SetCallDetails(CallDetails callDetails)
        //{
        //    callDetails.Add(callDetails);
        //}
        public double GetTotalCallCharge()
        {
            return totalCallCharge;
        }
        public double GetRental()
        {
            return rental;
        }
        public double GetTax()
        {
            return tax;
        }
        public double GetBillAmount()
        {
            return billAmount;
        }

        public void DisplayBill()
        {

        }
    }
}
