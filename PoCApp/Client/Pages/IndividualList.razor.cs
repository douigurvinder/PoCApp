using Microsoft.AspNetCore.Components;
using PoCApp.Client.Contracts;
using PoCApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PoCApp.Client.Pages
{
    public partial class IndividualList
    {
        [Inject]
        public IPocService _PocService { get; set; }
        public List<IndividualVW> Individuals { get; set; } = new List<IndividualVW>();

        public List<Country> Countries { get; set; } = new List<Country>();
        protected async override Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();

            await loadData();
        }

        private async Task  loadData()
        {
            Countries = (await _PocService.GetAllCountries()).ToList();

            Individuals = (await _PocService.GetAllIndividualVW(new Search())).ToList();
        }


    }
}
