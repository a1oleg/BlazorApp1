using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Google.Apis.Json;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace BlazorApp1.Data
{
    public class ValuesService
    {
        public async Task<string> GetAsync()
        {
            string local = "http://localhost:4001/graphql";
            string Pupstagram = "https://dog-graphql-api.glitch.me/graphql";
            string BTCboost = "https://48p1r2roz4.sse.codesandbox.io";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc = Encoding.GetEncoding("utf-8");


            using var graphQLClient = new GraphQLHttpClient(local, new NewtonsoftJsonSerializer());

            var personAndFilmsRequest = new GraphQLRequest
            {
                Query = @"
			    query Values($desc: String!) {
                    Values(desc: $desc)
                  }",
                OperationName = "Values",
                Variables = new
                {
                    desc = "Виды работ"
                }
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<ValueResponse>(personAndFilmsRequest);
            //return await graphQLClient.SendQueryAsync<PersonAndFilmsResponse>(personAndFilmsRequest);
            return (JsonSerializer.Serialize(graphQLResponse, new JsonSerializerOptions { WriteIndented = true }));
            
        }
    }
}
