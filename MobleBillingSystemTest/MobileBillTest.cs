﻿using System;
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
            billingEngine.SetCallDetailRecords("077-3902905", "077-0000000", new TimeSpan(15, 27, 0), 30);
            int expected = 1;
            int actual = billingEngine.GetCallDatailRecordsList().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GenerateaCallCharge_LocalCallinPeakOneMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(2018, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 60);

            double expected = 3;
            //Act
            Bill actual = billingEngine.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }


        [TestMethod]
        public void GenerateaCallCharge_LocalCallinOffPeakOneMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(2018, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(23, 00, 00), 60);

            double expected = 2;
            //Act
            Bill actual = billingEngine.Generate();

            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());

        }
        [TestMethod]
        public void GenerateaCallCharge_LongCallinPeakOneMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(2018, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "077-1111111", new TimeSpan(13, 00, 00), 60);

            double expected = 5;
            //Act
            Bill actual = billingEngine.Generate();

            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }

        [TestMethod]
        public void GenerateaCallCharge_LongCallinOffPeakOneMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(2018, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "077-1111111", new TimeSpan(23, 00, 00), 60);

            double expected = 4;
            //Act
            Bill actual = billingEngine.Generate();

            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }
        [TestMethod]
        public void GenerateCallCharge_LocalCallinPeakFiveMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(2018, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 300);

            double expected = 15;
            //Act
            Bill actual = billingEngine.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }
        [TestMethod]
        public void GenerateCallCharge_LongCallinPeakFiveMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(2018, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "075-1111111", new TimeSpan(12, 00, 00), 300);

            double expected = 25;
            //Act
            Bill actual = billingEngine.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }
        [TestMethod]
        public void GenerateaCallCharge_LocalCallinOffPeakFiveMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(22, 00, 00), 300);

            double expected = 10;
            //Act
            Bill actual = billingEngine.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }
        [TestMethod]
        public void GenerateaCallCharge_LocngCallinOffPeakFiveMinute_AddingChargeToBill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "076-1111111", new TimeSpan(22, 00, 00), 300);

            double expected = 20;
            //Act
            Bill actual = billingEngine.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
        }
        [TestMethod]
        public void Genarate_CallInLocalwithPeekTimeinSeconds_bill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(12, 40, 00), 300);

            double expected = 138;
            //act
            Bill actual = billingEngine.Generate();
            //assert
            Assert.AreEqual(expected, actual.GetBillAmount());
        }

        [TestMethod]
        public void Genarate_CallInLocalwithOffPeekTimeinSeconds_bill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(22, 40, 00), 300);

            double expected = 132;
            //act
            Bill actual = billingEngine.Generate();
            //assert
            Assert.AreEqual(expected, actual.GetBillAmount());
        }

        [TestMethod]
        public void Genarate_CallInLongwithPeekTimeinSeconds_bill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "076-1111111", new TimeSpan(12, 40, 00), 300);

            double expected = 150;
            //act
            Bill actual = billingEngine.Generate();
            //assert
            Assert.AreEqual(expected, actual.GetBillAmount());
        }
        [TestMethod]
        public void Genarate_CallInLongwithOffPeekTimeinSeconds_bill()
        {
            //arrange
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "076-1111111", new TimeSpan(22, 40, 00), 300);

            double expected = 144;
            //act
            Bill actual = billingEngine.Generate();
            //assert
            Assert.AreEqual(expected, actual.GetBillAmount());
        }
        [TestMethod]
        public void Genarate_CallInLocal_withBothPeekTimeandOffPeekTime_bill()
        {
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "071-1111111", new TimeSpan(19, 58, 00), 300);

            double expected = 134.4;
            //act
            Bill actual = billingEngine.Generate();
            //assert
            Assert.AreEqual(expected, actual.GetBillAmount());
        }
        [TestMethod]
        public void Genarate_CallInLongwithBothPeekTimeandOffPeekTimeinSeconds_bill()
        {
            billingEngine.AddingNewCustomer("Sachini", "Galle", "071-0000000", 1, new DateTime(18, 1, 3));
            billingEngine.SetCallDetailRecords("071-0000000", "077-1111111", new TimeSpan(19, 58, 00), 300);

            double expected = 134.4;
            //act
            Bill actual = billingEngine.Generate();
            //assert
            Assert.AreEqual(expected, actual.GetBillAmount());
        }






    }
}
