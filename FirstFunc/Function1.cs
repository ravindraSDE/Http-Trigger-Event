using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FirstFunc
{
    public static class Function1
    {
        [FunctionName("BinarySearch")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger Binary Search function processed a request.");
            int key = Convert.ToInt16(req.Query["Key"]);
            string data = req.Query["Arr"];
            string[] Arr = data?.Split(',');
            int[] numbers = new int[Arr.Length];
            for (int i=0;i<Arr.Length;i++)
            {
                numbers[i] = Convert.ToInt32(Arr[i]);
            }
            int? result=BinarySearchIterative(numbers, key);

            string responseMessage = result!=null?"Key found on "+result: "Key not found";
               
            return new OkObjectResult(responseMessage);
        }

        public static int? BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return null;
        }

    }
}
