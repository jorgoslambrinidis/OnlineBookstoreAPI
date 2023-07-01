namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using OnlineBookstoreAPI.Models;

    public class HomeController : BaseApiController
    {
        
        [HttpGet("Quotes")]
        public async Task<ActionResult<IEnumerable<QuotesData>>> GetQuotes()
        {
            try
            {
                var quotesResult = await CallExternalApiQuotes();

                return Ok(quotesResult);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region Helper Methods

        [NonAction]
        public async Task<List<Quote>> CallExternalApiQuotes()
        {
            List<Quote> quotesData = new List<Quote>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://type.fit/api/quotes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(apiResponse))
                    {
                        quotesData = JsonConvert.DeserializeObject<List<Quote>>(apiResponse);
                    }
                }
            }

            return quotesData;
        }

        #endregion
    }
}
