using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EscapeRoomCritic.Tests.IntegrationTests
{
    public class Client
    {
        private HttpClient _client { get; }

        public Client(HttpClient client)
        {
            _client = client;
        }
    }
}
