﻿using System;
using ApiSdk.controller;
using AuthenticationSdk.core;
using AuthenticationSdk.util;
using SampleCode.data;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class PostMethod
    {
        // POST Request to Authorize the payment for a transaction.
        // Transaction details provided in the JSON File are sent along with the Request as Request Body
        private const string RequestTarget = "/pts/v2/payments/";
        private const string RequestJsonFilePath = "Resource\\request_payments.json";

        public static void Run()
        {
            try
            {
                var requestData = new RequestData();

                // Setting up Merchant Config
                var merchantConfig = new MerchantConfig
                {
                    RequestTarget = RequestTarget,
                    RequestType = Enumerations.RequestType.POST.ToString(),
                    RequestJsonData = requestData.JsonFileData(RequestJsonFilePath)
                };

                // Call to the Controller of API_SDK
                var apiController = new APIController(merchantConfig);
                var response = apiController.PostPayment();

                // printing the response details
                if (response != null)
                {
                    Console.WriteLine("\n v-c-correlation-id:{0}", response.GetResponseHeaderValue(response.Headers, "v-c-correlation-id"));
                    Console.WriteLine("\n Response Code:{0}", response.StatusCode);
                    Console.WriteLine("\n Response Message:{0}", response.Data);
                }
            }
            catch (Exception e)
            {
                ExceptionUtility.Exception(e.Message, e.StackTrace);
            }
        }
    }
}