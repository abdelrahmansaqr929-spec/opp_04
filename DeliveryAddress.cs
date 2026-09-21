using System;
using System.Collections.Generic;
using System.Text;


    namespace opp__04
    {
        public class DeliveryAddress
        {
            private string city;
            private string street;
            private string country;

            public string City
            {
                get { return city; }
                set { if (!string.IsNullOrWhiteSpace(value)) city = value; }
            }

            public string Street
            {
                get { return street; }
                set { if (!string.IsNullOrWhiteSpace(value)) street = value; }
            }

            public string Country
            {
                get { return country; }
                set { if (!string.IsNullOrWhiteSpace(value)) country = value; }
            }

            public DeliveryAddress()
            {
                city = "Unknown";
                street = "Unknown";
                country = "Egypt";
            }

            public DeliveryAddress(string city, string street, string country)
            {
                this.city = "Unknown";
                this.street = "Unknown";
                this.country = "Egypt";

                City = city;
                Street = street;
                Country = country;
            }
        }
    }
