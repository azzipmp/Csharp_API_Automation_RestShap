//  Rest API's automation using the REST SHARP library :
 //  GET : Method
 // Rest sharp library 
var client = new RestClient("http://localhost:9999");
var request = new RestRequest("api/item/", Method.GET);
request.AddHeader( "clientId", clientId );
request.AddHeader( "Authorization", $"Bearer {authorizationToken}" );
request.AddParameter("auth_token", "1234"); 
//request.AddBody(json);
//request.AddQueryParameter("auth_token", "1234); 

response = await client.ExecuteAsync<T>( request );  // T could be Custom ITEM class with properties
//Convert String to object
var contract = JsonConvert.DeserializeObject<T>( response.Content );



//DTO
public class Item
{
 public string StockNumber { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
     
		
		}

// Post Method

var client = new RestClient("http://localhost:9999");
var request = new RestRequest("api/item/", Method.POST);
request.RequestFormat = DataFormat.Json;
request.AddBody(new Item
{
    ItemName = someName,
    Price = 19.99
});
response=  client.execute(request);


//Delete with query parameters

var client = new RestClient("http://localhost:9999");
var request = new RestRequest("api/item/{id}", Method.Delete);
request.AddQueryParameter("id", idItem);
response = client.Execute(request)

//compare JSON using Fluent Assertions:

using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json;

//The JToken class represents JSON who's type (Object, Array, Property, etc) will be determined at run-time based on the JSON you feed it.
//Convert string Json to Jtoken and compare.

JToken expected = JToken.Parse(@"{ ""Name"": ""20181004164456"", ""objectId"":"4ea%>"" }");
JToken actual =  JToken.Parse(@"{ ""Name"": ""AAAAAAAAAAAA"", ""objectId"":b1%>"" }");

actual.should().BeEquivalentTo(expected)

//.Or using deserilize the JSON and compare

  expectedObject = JsonConvert.DeserializeObject<Entity>(jsonExpected);
    actualObject = JsonConvert.DeserializeObject<Entity>(jsonActual);

 actualObject.Should().BeEquivalentTo(expectedObject);