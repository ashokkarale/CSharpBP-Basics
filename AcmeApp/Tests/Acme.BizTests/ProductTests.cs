using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {

            //Arrenge
            var currentParrent = new Product();
            currentParrent.ProductName = "Saw";
            currentParrent.ProductId = 1;
            currentParrent.Description = "15-inch steel blade hand saw";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            //Act
            var actual = currentParrent.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_PrameterizedConstructorTest()
        {

            //Arrenge
            var currentParrent = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            //Act
            var actual = currentParrent.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}