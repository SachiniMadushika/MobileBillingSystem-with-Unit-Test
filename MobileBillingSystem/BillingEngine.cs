using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBillingSystem;

namespace MobileBillingSystem
{
    public class BillingEngine
    {
        Customer customer;
        List<CallDatailRecords> callDetailList = new List<CallDatailRecords>();
        TimeSpan PeekStartTime = new TimeSpan(8, 0, 0);
        TimeSpan PeekEndTime = new TimeSpan(20, 0, 0);
        int LocalPeekCallCharge = 3;
        int LocalOffPeekCallCharge = 2;
        int LongPeekCallCharge = 5;
        int LongOffPeekCallCharge =4 ;
        double RateofTax = 0.2;


        public Bill Generate()
        {
            Bill bill = new Bill(customer);
            bill.SetRental(100);
            double totalCallCharge = 0;
            foreach( var call in callDetailList)
            {
                if(call.GetCallerNumber() == customer.getPhoneNumber())
                {
                    double calculateChargerForCallTime = CalculateChargerForCallTime(call);
                    totalCallCharge = totalCallCharge + calculateChargerForCallTime;
                    CallDetails callDetails = new CallDetails(call.GetStartingTimeofCall(), call.GetDurationinSeconds(), call.GetReceiverNumber(), calculateChargerForCallTime);
                    //bill.SetCallDetails(callDetails);
                }
            }
            //bill.SetRental();
            bill.SetTotalCallCharge(totalCallCharge);
            bill.SetTax(AddingTax(bill.GetTotalCallCharge(), bill.GetRental()));
            bill.SetBillAmount(CalculateTotalBillAmount(bill.GetTotalCallCharge(), bill.GetRental(), bill.GetTax()));

            return bill;
        }


        public bool IsLocalCall(string callerNumber, string receiverNumber)
        {
            string extensionOfCallerNumber = callerNumber.Split('-')[0];
            string extensionOfReceiverNumber = receiverNumber.Split('-')[0];
            if (extensionOfCallerNumber == extensionOfReceiverNumber)
            {
                return true;
            }
            else
                return false;
        }

        //public string CheckPackageType()
        //{
        //    switch (customer.getPackageName())
        //    {
        //        case 'A':
        //            return new Package-A();
        //        case 'B':
        //            return new Package-B();
        //        case 'C':
        //            return new Package-C();
        //        case 'D':
        //            return new Package-D();
        //    }
        //}

        public double CalculateSecondsToMinutes(int durationInSeconds)
        {
            double durationInMinutes = durationInSeconds / 60;
            return durationInMinutes;
        }

        public double PeekTimeChargeCalculate(TimeSpan callStartedTime, int durationInSeconds, bool localCall)
        {        
            double charge = 0;
            for (int a = 0; a < CalculateSecondsToMinutes(durationInSeconds); a++)
            {
                if (callStartedTime >= PeekStartTime && callStartedTime < PeekEndTime)
                {
                    if (localCall)
                    {
                        charge = charge + LocalPeekCallCharge;
                    }
                    else
                    {
                        charge = charge + LongPeekCallCharge;
                    }

                }
                else
                {
                    if (localCall)
                    {
                        charge = charge + LocalOffPeekCallCharge;
                    }
                    else
                    {
                        charge = charge + LongOffPeekCallCharge;
                    }
                }
            }
            return charge;
        }
        public double CalculateChargerForCallTime(CallDatailRecords call)
        {
            int durationInSecond = call.GetDurationinSeconds();
            if (IsLocalCall(call.GetCallerNumber(), call.GetReceiverNumber()))
            {
                return PeekTimeChargeCalculate(call.GetStartingTimeofCall(), durationInSecond, true);
            }
            else
            {
                return PeekTimeChargeCalculate(call.GetStartingTimeofCall(), durationInSecond, false);
            }
        }
        public double AddingTax(double totalCallCharge, double rental)
        {
            return (totalCallCharge + rental) * RateofTax;
        }
  
        public double CalculateTotalBillAmount(double totalCallCharge, double rental, double tax)
        {
            return totalCallCharge + rental + tax;
        }

        public Customer AddingNewCustomer(String Full_Name, string Address, string Phone_Number, int Package_Code, DateTime Registered_Date)
        {
            customer = new Customer(Full_Name, Address, Phone_Number, Package_Code, Registered_Date);
            return customer;
        }

        public Customer GetCustomer()
        {
            return customer;
        }
        public List<CallDatailRecords> GetCallDatailRecordsList()
        {
            return callDetailList;
        }
        public CallDatailRecords SetCallDetailRecords(string Caller_Number, string Receiver_Number, TimeSpan StartingTimeofCall, int DurationinSeconds)
        {
            CallDatailRecords callDetailRecord = new CallDatailRecords(Caller_Number, Receiver_Number, StartingTimeofCall, DurationinSeconds);
            callDetailList.Add(callDetailRecord);
            return callDetailRecord;
        }

    }
}
