using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillingSystem
{
    public class CallDetails
    {
        TimeSpan startTime;
        int durationInSeconds;
        string receiverNumber;
        double charge;

        public CallDetails(TimeSpan startTime, int durationInSeconds, string receiverNumber, double charge)
        {
            this.startTime = startTime;
            this.durationInSeconds = durationInSeconds;
            this.receiverNumber = receiverNumber;
            this.charge = charge;
        }
        public TimeSpan GetStartTime()
        {
            return startTime;
        }
        public int GetDurationInSeconds()
        {
            return durationInSeconds;
        }
        public string GetReceiverNumber()
        {
            return receiverNumber;
        }
        public double GetCharge()
        {
            return charge;
        }

        public void DisplayBill()
        {
            //Console.WriteLine("Start Time:" + startTime);
            //Console.WriteLine("Duration in seconds:" + durationInSeconds);
            //Console.WriteLine("Receiver number:" + receiverNumber);
            //Console.WriteLine("Charge:" + charge);
        }
    }
}
