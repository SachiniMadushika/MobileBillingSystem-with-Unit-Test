using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileBillingSystem;

namespace MobleBillingSystem.test
{
    [TestClass]
    public class MobileBillTest
    {
        BillingEngine billingEngine;

        [TestInitialize]
        public void init()
        {
            billingEngine = new BillingEngine();
        }

        [TestMethod]
        public void CustomerDetails_Compared_CustomerAddedData()
        {
            //arrange
            Customer actual = billingEngine.AddingNewCustomer("Sachini Madushika", "1st lane, Elpitiya", "077-3902905", 1, new DateTime(2017, 12, 28, 17, 12, 23));
            //act
            Customer expected = new Customer("Sachini Madushika", "1st lane, Elpitiya", "077-3902905", 1, new DateTime(2017, 12, 28, 17, 12, 23));

            //assert
            Assert.AreEqual(expected.getFullName(), actual.getFullName());
            Assert.AreEqual(expected.getAddress(), actual.getAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.getPhoneNumber());
            Assert.AreEqual(expected.getPackageCode(), actual.getPackageCode());
            Assert.AreEqual(expected.getRegisteredDate(), actual.getRegisteredDate());

        }
        [TestMethod]
        public void CDRDetails_Compared_CDRAddedData()
        {
            billingEngine.SetCallDetailRecords("077-3902905", "077-0000000", new TimeSpan( 15, 27, 0), 30);
            int expected = 0;
            int actual = billingEngine.GetCallDatailRecordsList().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CallInLocal_withPeekTime_bill()
        {
            billingEngine.AddingNewCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 60);

            double expected = 3;
            //Act
            Bill actual = billingEngine.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }
        [TestMethod]
        public void CallInLocal_withOffPeekTime_bill()
        {

        }
        [TestMethod]
        public void CallInLong_withPeekTime_bill()
        {

        }
        [TestMethod]
        public void CallInLong_withOffPeekTime_bill()
        {

        }
        [TestMethod]
        public void CallInLocal_withBothPeekTimeandOffPeekTime_bill()
        {

        }
        [TestMethod]
        public void CallInLong_withBothPeekTimeandOffPeekTime_bill()
        {

        }






    }
}
