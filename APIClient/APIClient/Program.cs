using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace APIClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//var restClient = new RestClient("http://api.postcodes.io/");
			//var restRequest = new RestRequest();
			//restRequest.Method = Method.GET;
			//restRequest.AddHeader("Content-Type", "application/json");
			//restRequest.Timeout = -1;

			//var postcode = "EC2Y 5AS";
			//restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

			//var restResponse = restClient.Execute(restRequest);

			//Console.WriteLine($"Response content {restResponse.Content}");

			//var jsonResponse = JObject.Parse(restResponse.Content);
			//Console.WriteLine($"\nResponse content as a JObject");
			//Console.WriteLine($"{ jsonResponse}");

			//var adminDistrict = jsonResponse["result"]["admin_district"];
			//var adminWard = jsonResponse["result"]["admin_ward"];
			//var latitude = jsonResponse["result"]["latitude"];
			//Console.WriteLine($"\nAdmin district: {adminDistrict}");
			//Console.WriteLine($"\nAdmin ward: {adminWard}");
			//Console.WriteLine($"\nLatitude: {latitude}");

			//var singlePostcode = JsonConvert.DeserializeObject<SinglePostcodeResponse>(restResponse.Content);
			//Console.WriteLine(singlePostcode.result.admin_district);

			//var client = new RestClient("https://api.postcodes.io/postcodes/ec2y5as");
			//client.Timeout = -1;
			//var request = new RestRequest(Method.GET);
			//request.AddHeader("Cookie", "__cfduid=dc591b23a0e6a4b33e3cf7db5683718641606127575");
			//IRestResponse response = client.Execute(request);
			//Console.WriteLine(response.Content);

			//var client = new RestClient("https://api.postcodes.io/postcodes/");
			//client.Timeout = -1;
			//var request = new RestRequest(Method.POST);
			//request.AddHeader("Content-Type", "application/json");
			//request.AddHeader("Cookie", "__cfduid=dc591b23a0e6a4b33e3cf7db5683718641606127575");
			//request.AddParameter("application/json", "{\r\n  \"postcodes\" : [\"PR3 0SG\", \"M45 6GN\", \"EX165BL\"]\r\n}", ParameterType.RequestBody);
			//IRestResponse response = client.Execute(request);
			//Console.WriteLine(response.Content);

			//var bulkJsonResponse = JObject.Parse(response.Content);
			//var adminDistrict2 = bulkJsonResponse["result"][1]["result"]["admin_district"];
			//var nutsCode = bulkJsonResponse["result"][0]["result"]["codes"]["nuts"];

			//var bulkPostCodes = JsonConvert.DeserializeObject<BulkPostcodeResponse>(response.Content);

			//Console.WriteLine(bulkPostCodes.result[0].result.codes.nuts);

			StartOfPostCode("EX33");

			//StartOfPostCode(["EX33", "EX32"]);
		}

		public static void StartOfPostCode(string outcode)
		{
			var restClient = new RestClient("http://api.postcodes.io/outcodes/");
			var restRequest = new RestRequest();
			restRequest.Method = Method.GET;
			restRequest.AddHeader("Content-Type", "application/json");
			restRequest.Timeout = -1;

			restRequest.Resource = $"{outcode.ToLower()}";

			var restResponse = restClient.Execute(restRequest);

			Console.WriteLine($"{JObject.Parse(restResponse.Content)}");

			var newOutcode = JsonConvert.DeserializeObject<BulkOutcodeResponse>(restResponse.Content);
			
			foreach(var item in newOutcode.result.parish)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine($"\n{newOutcode.result.longitude}");

		}

		public static void StartOfPostCode(string[] outcodes)
		{
			var client = new RestClient("https://api.postcodes.io/outcodes/");
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Content-Type", "application/json");
			//request.AddHeader("Cookie", "__cfduid=dc591b23a0e6a4b33e3cf7db5683718641606127575");
			//request.AddParameter("application/json", "{\r\n  \"outcode\" : [\"PR3\", \"M45\"]\r\n}", ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
		}

		
	}
}
