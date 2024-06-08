using Amazon.Lambda;
using Amazon.Lambda.Model;
using Newtonsoft.Json;
using Order_Processing_Serverless_in_aws.Models;
using System.Threading.Tasks;

namespace Order_Processing_Serverless_in_aws.Services
{
    public interface IOrderProcessing
    {
        Task<dynamic> InvokeLambdaFunction(Order orderjson);
    }
    public class Order_Processing_Serverless: IOrderProcessing
    {
        public async Task<dynamic> InvokeLambdaFunction(Order orderjson)
        {
            using var lambdaClient = new AmazonLambdaClient();

            var request = new InvokeRequest
            {
                FunctionName = "OrderFunction",
                InvocationType = InvocationType.Event,
                Payload = JsonConvert.SerializeObject(orderjson)
            };
            var response = await lambdaClient.InvokeAsync(request);
           
            return Task.CompletedTask;
        }

    }
}

    
