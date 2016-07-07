﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tests
{
    [TestClass()]
    public class MyPriceReducerTests
    {
        IEnumerable<Product> products;

        [TestInitialize]
        public void PreTestInitialize()
        {
            //initialize products before each test
        }

        [TestMethod]
        public void All_Prices_Are_Changed()
        {
            //Arrange   I
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            IEnumerable<decimal> prices = repo.GetProducts().Select(e => e.Price);
            decimal[] initialPrices = prices.ToArray();
            MyPriceReducer target = new MyPriceReducer(repo);

            //Act       R
            target.ReducePrices(reductionAmount);

            //Assert    D
            prices.Zip(initialPrices, (p1, p2) =>
            {
                if (p1 == p2)
                {
                    Assert.Fail();
                }
                return p1;
            });
        }

        [TestMethod]
        public void Correct_Total_Reduction_Amount()
        {
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            decimal initialTotal = repo.GetTotalValue();
            MyPriceReducer target = new MyPriceReducer(repo);

            target.ReducePrices(reductionAmount);

            Assert.AreEqual(repo.GetTotalValue(),
                (initialTotal - (repo.GetProducts().Count() * reductionAmount)));
        }

        [TestMethod]
        public void No_Price_Less_Than_One_Dollar()
        {
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = decimal.MaxValue;
          MyPriceReducer target = new MyPriceReducer(repo);

            target.ReducePrices(reductionAmount);

            foreach (Product prod in repo.GetProducts())
            {
                Assert.IsTrue(prod.Price >= 1);
            }
        }
    }
}