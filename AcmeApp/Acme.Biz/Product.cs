using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created");
            this.MinimumPrice = .96m;
        }

        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            this.MinimumPrice = 9.99m;
            Console.WriteLine("Product instance has a name: " + ProductName);
        } 
        #endregion

        #region Properties
        private DateTime? availibilityDate;

        public DateTime? AvailibilityDate
        {
            get { return availibilityDate; }
            set { availibilityDate = value; }
        }

        private string productName;

        public string ProductName
        {
            get {
                var formatedValue = productName?.Trim();
                return formatedValue;
            }
            set {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be at more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message for product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", ProductName, "sales@abc.com");

            var result = LogAction("saying hello!");
            
            return "Hello " + ProductName + " (" + ProductId + "): " + Description + " Available on: " + AvailibilityDate?.ToShortDateString();

        }
    }
}
