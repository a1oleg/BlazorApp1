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
        static string local = "http://localhost:4001/graphql";

        GraphQLHttpClient graphQLClient = new GraphQLHttpClient(local, new NewtonsoftJsonSerializer());

        public string qu  { get; set; }
        public ValuesService(string q)
        {
            qu = q;
        }
        public async Task<Rootobject> GetAsync()
        {                        
            

            var request = new GraphQLRequest   

            {
                
                Query = qu,
       //         @"
			    //query Dirs {
       //               Dirs
       //           }",
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
