using API.Models;
using Client.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Pages
{
    public partial class CoffeShops
    {
        private List<CoffeShopModel> Shops = new();
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IConfiguration config { get; set; }
        [Inject] private ITokenService TokenService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenResponse = await TokenService.GetToken("CoffeeAPI.read");
            HttpClient.SetBearerToken(tokenResponse.AccessToken);

            var result = await HttpClient.GetAsync(config["apiUrl"] + "/api/CoffeShop");

            if (result.IsSuccessStatusCode)
            {
                Shops = await result.Content.ReadFromJsonAsync<List<CoffeShopModel>>();
            }
        }

    }
}
