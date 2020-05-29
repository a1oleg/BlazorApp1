using System;
using System.Globalization;
using System.Linq;
using System.Text;
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
        public async Task<string> GetAsync()
        {
            string local = "http://localhost:4001/graphql";
            
            using var graphQLClient = new GraphQLHttpClient(local, new NewtonsoftJsonSerializer());



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

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            var graphQLResponse = await graphQLClient.SendQueryAsync<ValueResponse>(request);
            
            return System.Text.Json.JsonSerializer.Serialize(graphQLResponse, jso);
            
        }
    }
}
