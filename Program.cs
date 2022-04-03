using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace azure_msal
{
    class Program
    {
        private const string _clientId = "5a56581e-6174-488e-a089-7bfe5efeb917";
        private const string _tenantId = "749cef82-fcec-4880-8439-2513103dab93";

        static async Task Main(string[] args)
        {
            // build out the authorization context
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("http://localhost")
                .Build();

            // Get token
            string[] scopes = { "user.read" };

            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
