using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Models;
using System.Collections.Generic;

namespace TDD.Tests
{
    [TestClass]
    public class CategoryModelsTest
    {
        [TestMethod]
        public void Test_Category_Products()
        {
            //1
            Category TestCategory = new Models.Category();
            TestCategory.CategoryID = 1;

            //2 
            var result = TestCategory.GetProducts();

            //3
            Assert.AreEqual(typeof(List<Product>),result.GetType());
            
        }
    }
}
