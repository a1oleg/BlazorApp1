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
    public class PersonAndFilmsService
    {
        public async Task<string> GetAsync()
        {
            using var graphQLClient = new GraphQLHttpClient("https://swapi.apis.guru/", new NewtonsoftJsonSerializer());

            var personAndFilmsRequest = new GraphQLRequest
            {
                Query = @"
			    query PersonAndFilms($id: ID) {
			        person(id: $id) {
			            name
			            filmConnection {
			                films {
			                    title
			                }
			            }
			        }
			    }",
                OperationName = "PersonAndFilms",
                Variables = new
                {
                    id = "cGVvcGxlOjE="
                }
            };

            
            var graphQLResponse = await graphQLClient.SendQueryAsync<PersonAndFilmsResponse>(personAndFilmsRequest);
            //return await graphQLClient.SendQueryAsync<PersonAndFilmsResponse>(personAndFilmsRequest);
            return (JsonSerializer.Serialize(graphQLResponse, new JsonSerializerOptions { WriteIndented = true }));


            //Console.WriteLine("raw response:");
            //Console.WriteLine(JsonSerializer.Serialize(graphQLResponse, new JsonSerializerOptions { WriteIndented = true }));

            //Console.WriteLine();
            //Console.WriteLine($"Name: {graphQLResponse.Data.Person.Name}");
            //var films = string.Join(", ", graphQLResponse.Data.Person.FilmConnection.Films.Select(f => f.Title));
            //Console.WriteLine($"Films: {films}");

            //Console.WriteLine();
            //Console.WriteLine("Press any key to quit...");
            //Console.ReadKey();
        }
    }
}
