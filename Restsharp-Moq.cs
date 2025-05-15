//Rest sharp moq in the response

//Moq the response and status

import moq;
public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json)
            where T : new()
        {
            var data = JsonConvert.DeserializeObject<T>(json);
            var response = new Mock<IRestResponse<T>>();
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            
            mockIRestClient
              .Setup(x => x.Execute<T>(It.IsAny<IRestRequest>()))
              .Returns(response.Object);
            
            return mockIRestClient.Object;
        }
    }

    public class User
    {
        public string Name { get; set; }
    }


public void Moqtest()
        {
            var client = MockRestClient<User>(HttpStatusCode.OK, "{\"Name\":\"User1\"}");
            var restRequest = new RestRequest("api/item/", Method.POST);
            var restResponse = client.Execute<User>(restRequest);

            var user = restResponse.Data;

            Assert.AreEqual("User1", user.Name);
        }
