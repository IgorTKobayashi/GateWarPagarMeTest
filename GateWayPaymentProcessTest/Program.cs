using PagarmeCoreApi.PCL;
using PagarmeCoreApi.PCL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GateWayPaymentProcessTest
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            // you can put the key on the UserName and left the password in blank for the test
            // Configuration parameters and credentials
            string basicAuthUserName = ""; // The username to use with basic authentication
            string basicAuthPassword = ""; // The password to use with basic authentication

            var client = new PagarmeCoreApiClient(basicAuthUserName, basicAuthPassword);

            var request = new CreateOrderRequest
            {
                Payments = new List<CreatePaymentRequest>
                {

                    new CreatePaymentRequest
                    {
                        PaymentMethod = "Pix",
                        Amount = 1742,
                        Pix = new CreatePixPaymentRequest{
                            ExpiresIn = 5000,
                            AdditionalInformation = new List<PixAdditionalInformation>
                            { 
                                new PixAdditionalInformation 
                                {
                                    Name = "quantidade", Value="1" 
                                } 
                            }
                        }
                    }
                },
                Items = new List<CreateOrderItemRequest>
                {
                    new CreateOrderItemRequest
                    {
                        Amount = 2990,
                        Description = "Chaveiro do Tesseract",
                        Quantity = 1
                    }
                },
                Customer = new CreateCustomerRequest
                {
                    Name = "sdk customer order",
                    Email = "tonystark@avengers.com",
                    Type = "individual",
                    Document = "01234567890"
                }
            };

            var response = client.Orders.CreateOrder(request);

            Console.WriteLine(response);
            Console.ReadKey();

        }

    }
}
