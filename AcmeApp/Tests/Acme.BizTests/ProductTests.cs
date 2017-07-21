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
            currentParrent.ProductVendor.CompanyName = "ABC Corp.";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw"+" Available on: ";

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
            var expected = "Hello Saw (1): 15-inch steel blade hand saw Available on: ";

            //Act
            var actual = currentParrent.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrenge
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;

            //Act
            var actual = companyName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetresToInchesTest()
        {
            //Arrenge
            var expected = 78.74;
            //Act
            var actual = 2 * Product.InchesPerMeter;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //Arrenge
            var currentProduct = new Product();
            var expected = .96m;
            //Act
            var actual = currentProduct.MinimumPrice;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //Arrenge
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.99m;
            //Act
            var actual = currentProduct.MinimumPrice;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Format()
        {
            //Arrenge
            var currentProduct = new Product();
            currentProduct.ProductName = " Steel Hammer  ";
            var expected = "Steel Hammer";
            //Act
            var actual = currentProduct.ProductName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_TooShort()
        {
            //Arrenge
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";
            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_TooLong()
        {
            //Arrenge
            var currentProduct = new Product();
            currentProduct.ProductName = "Andrew Helthy Sam Delta Thima";
            string expected = null;
            string expectedMessage = "Product Name cannot be at more than 20 characters";
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void ProductName_JustRight()
        {
            //Arrenge
            var currentProduct = new Product();
            currentProduct.ProductName = "Ask";
            string expected = "Ask";
            string expectedMessage = null;
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}