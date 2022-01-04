using FinancialTools.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinancialTools
{
    public static class ComicProcessor
    {
        public static async Task<ComicModel> LoadComic(int ComicNumber = 0)
        {
            string url = "";

            if (ComicNumber > 0)
            {
                url = $"http://xkcd.com/{ ComicNumber}/info.0.json";
            }
            else
            {
                url="http://xkcd.com/info.0.json"; 
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

    }
}
