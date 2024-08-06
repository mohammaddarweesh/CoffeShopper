using API.Models;
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

        protected override async Task OnInitializedAsync()
        {
            var result = await HttpClient.GetAsync(config["apiUrl"] + "/api/CoffeShop");

            if (result.IsSuccessStatusCode)
            {
                Shops = await result.Content.ReadFromJsonAsync<List<CoffeShopModel>>();
            }
        }

    }
}
