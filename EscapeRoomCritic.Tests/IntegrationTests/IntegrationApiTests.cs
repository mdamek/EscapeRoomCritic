using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dapper;
using EscapeRoomCritic.Core.DTOs.EscapeRooms;
using EscapeRoomCritic.Core.DTOs.Identity;
using EscapeRoomCritic.Core.DTOs.Reviews;
using EscapeRoomCritic.Core.DTOs.Statistics;
using EscapeRoomCritic.Core.DTOs.Users;
using EscapeRoomCritic.Core.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace EscapeRoomCritic.Tests.IntegrationTests
{
    public class IntegrationApiTests
    {
        private HttpClient Client { get; set; }
        private string Token { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Client = WebHostProvider.CreateHttpClient();
            ResetDataBase();
            GetLoginToken();
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);
        }

        [Test]
        public async Task Common_Scenario_EscapeRooms_Reviews_And_Statistic()
        {
            var users = Client.GetAsync("api/users").Result.Content.ReadAsAsync<ICollection<UserDto>>().Result;
            Assert.AreEqual(1, users.Count);
            var userId = users.First().Id;
            var escapeRoom = new NewEscapeRoomDto
            {
                BuildingNumber = 30, Category = Category.Abstract, City = "Kraków", Time = 80, Name = "StrasznyDwor",
                Email = "mads@sds.com", Description = "Super hard escape room", Price = 150,
                ForAdult = true, PhoneNumber = "433256643", MaxPeopleNumber = 5, Street = "BakerStreet"
            };
            await Client.PostAsJsonAsync("api/escaperooms", escapeRoom);
            var allEscapeRooms = await Client.GetAsync("api/escaperooms").Result.Content.ReadAsAsync<ICollection<EscapeRoomDto>>();
            Assert.AreEqual(1, allEscapeRooms.Count);
            var actualEscapeRoom = allEscapeRooms.First();
            Assert.AreEqual(escapeRoom.Category, actualEscapeRoom.Category);
            Assert.AreEqual(escapeRoom.Description, actualEscapeRoom.Description);
            Assert.AreEqual(escapeRoom.Name, actualEscapeRoom.Name);
            var editEscapeRoom = new EditEscapeRoomDto
            {
                ForAdult = escapeRoom.ForAdult,
                BuildingNumber = escapeRoom.BuildingNumber,
                Category = escapeRoom.Category,
                City = escapeRoom.City,
                Description = escapeRoom.Description,
                Email = escapeRoom.Email,
                MaxPeopleNumber = escapeRoom.MaxPeopleNumber,
                Name = "EDITEDNAME",
                PhoneNumber = escapeRoom.PhoneNumber,
                Price = 200,
                Id = actualEscapeRoom.Id

            };
            await Client.PutAsJsonAsync("api/escaperooms", editEscapeRoom);
            var afterEditEscapeRoom = await Client.GetAsync($"api/escaperooms/{actualEscapeRoom.Id}").Result.Content.ReadAsAsync<EscapeRoomDto>();
            //Assert.AreEqual("EDITEDNAME", afterEditEscapeRoom.Name);
            //Assert.AreEqual(200, afterEditEscapeRoom.Price);
            await Client.DeleteAsync($"api/escaperooms/{actualEscapeRoom.Id}");
            var allEscapeRoomsAfterDelete = await Client.GetAsync("api/escaperooms").Result.Content.ReadAsAsync<ICollection<EscapeRoomDto>>();
            Assert.AreEqual(0, allEscapeRoomsAfterDelete.Count);
            await Client.PostAsJsonAsync("api/escaperooms", escapeRoom);
            allEscapeRooms = await Client.GetAsync("api/escaperooms").Result.Content.ReadAsAsync<ICollection<EscapeRoomDto>>();
            Assert.AreEqual(1, allEscapeRooms.Count);
            actualEscapeRoom = allEscapeRooms.First();
            var review1 = new NewReviewDto
            {
                UserId = userId,
                Content = "AwesomeTestRoom",
                EscapeRoomId = actualEscapeRoom.Id,
                Rating = Rating.Eight,
                Title = "Great"
            };
            await Client.PostAsJsonAsync("api/reviews", review1);
            var allReviews = Client.GetAsync($"api/reviews/byUser/{userId}").Result.Content.ReadAsAsync<ICollection<ReviewForUserDto>>().Result;
            Assert.AreEqual(1, allReviews.Count);
            var statistics = Client.GetAsync("api/statistics/CityStatistics/Kraków").Result.Content
                .ReadAsAsync<CityStatisticsDto>().Result;
            Assert.AreEqual(80, statistics.AverageGameTime);
            Assert.AreEqual(150, statistics.AveragePrice);
            Assert.AreEqual(8, statistics.AverageRating);
            Assert.AreEqual(1, statistics.EscapeRoomsNumber);
            Assert.AreEqual(new Dictionary<string, int>{{ "Abstract", 1} }, statistics.FamousTypes);
        }

        private void GetLoginToken()
        {
            var testCredentials = new Credentials
            {
                Username = "testUser",
                Password = "testPassword"
            };
            var answer = Client.PostAsJsonAsync("api/authorization/authenticate", testCredentials).Result;
            Token = JObject.Parse(answer.Content.ReadAsStringAsync().Result)["token"].ToString().Split(' ')[1];
        }

        private static void ResetDataBase()
        {
            using (var connection = new SqlConnection(WebHostProvider.GetConnectionString()))
            {
                connection.Execute("DELETE FROM Reviews;");
                connection.Execute("DELETE FROM EscapeRooms;");
                connection.Execute("DELETE FROM Users;");
                connection.Execute(
                    "INSERT INTO Users VALUES ('Tester', 'Test', 'testUser', 'testPassword', 'Admin');");
            }
        }
    }
}
