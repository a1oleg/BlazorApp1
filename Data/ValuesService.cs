using System.Text.Json;
using System.Threading.Tasks;
//using Google.Apis.Json;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using BlazorApp1.Pages;

namespace BlazorApp1.Data
{
    public class ValuesService
    {        
        public async Task<Rootobject> GetAsync(string route)
        {
            string local = "http://localhost:4001/graphql";

            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(local, new NewtonsoftJsonSerializer());


            GraphQLRequest request = new GraphQLRequest
            {                
                Query = route//,
       //         @"
			    //query Dirs {
       //               Dirs
       //           }",
                //OperationName = "Dirs"
            };



            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<Data>(request);
            graphQLClient.Dispose();
            //return System.Text.Json.JsonSerializer.Serialize(graphQLResponse, jso);
            return JsonConvert.DeserializeObject<Rootobject>(System.Text.Json.JsonSerializer.Serialize(graphQLResponse, jso));
        }
    }
}
