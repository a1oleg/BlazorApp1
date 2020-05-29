using System.Text.Json;
using System.Threading.Tasks;
//using Google.Apis.Json;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;

namespace BlazorApp1.Data
{
    public class ValuesService
    {

        public async Task<Rootobject> GetAsync()
        {
            string local = "http://localhost:4001/graphql";
            
            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(local, new NewtonsoftJsonSerializer());



            var request = new GraphQLRequest
       //     {
       //         Query = @"
			    //query Values($desc: String!) {
       //             Values(desc: $desc)
       //           }",
       //         OperationName = "Values",
       //         Variables = new
       //         {
       //             desc = "Виды работ"
       //         }
       //     };

            {
                Query = @"
			    query Dirs {
                      Dirs
                  }",
                OperationName = "Dirs"
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
