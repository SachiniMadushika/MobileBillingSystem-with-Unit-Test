using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillingSystem
{
    public class CallDatailRecords
    {
        string Caller_Number;
        string Receiver_Number;
        TimeSpan StartingTimeofCall;
        int DurationinSeconds;

        public CallDatailRecords(string Caller_Number, string Receiver_Number, TimeSpan StartingTimeofCall, int DurationinSeconds)
        {
            this.Caller_Number = Caller_Number;
            this.Receiver_Number = Receiver_Number;
            this.StartingTimeofCall = StartingTimeofCall;
            this.DurationinSeconds = DurationinSeconds;
        }

        public string GetCallerNumber()
        {
            return Caller_Number;
        }
        public string GetReceiverNumber()
        {
            return Receiver_Number;
        }
        public TimeSpan GetStartingTimeofCall()
        {
            return StartingTimeofCall;
        }
        public int GetDurationinSeconds()
        {
            return DurationinSeconds;
        }

    }
}
