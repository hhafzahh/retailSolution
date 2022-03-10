using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;

namespace orderMicroservice
{
    public class MakePayment
    {
        public static async Task<dynamic> PayAsync(string cardNumber, int month, int year, string cvc, int totalPrice)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51Jtm3AFm1p2oN63WlfXlSRojBCckqUMleQfgo5xbbyeT1CB4Ukx6wyGZ2UaIq7IHgRxoAi86l4K3qwq7kX6xWaNq00vKXRsDsZ";
                var optionstoken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = month,
                        ExpYear = year,
                        Cvc = cvc,


                    }

                };

                var servicetoken = new TokenService();
                Token stripetoken = await servicetoken.CreateAsync(optionstoken);

                //to charge 
                var options = new ChargeCreateOptions()
                {
                    Amount = totalPrice,
                    Currency = "sgd",
                    Description = "test1" ,
                    //the source is the cardId
                    Source = stripetoken.Id
                };
                var service = new ChargeService();
                //options here is the CHARGE OPTIONS
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                   return "success";
                   // return "You have successfully ordered your items!";
                    
                }
                else
                {
                    return "failed";
                }
            }

            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}