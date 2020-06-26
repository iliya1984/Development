using BoltTest.Client.Interfaces;
using BoltTest.Core.Interfaces;
using BoltTest.Entities.Responses;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BoltTest.Client
{
    internal class SearchClient : ISearchClient
    {
        private ILoggingService _logger;
        private const string BaseApiUrl = "https://localhost:44318/api";

        public SearchClient(ILoggerFactory loggerFactory) 
        {
            _logger = loggerFactory.GetLoggerForType<SearchClient>();
        }

        public async Task<SearchResponse> SearchAsync(string queryWord)
        {
            try
            {
                using(var httpClient = new HttpClient()) 
                {
                    string url = string.Format("{0}?queryword={1}", BaseApiUrl, queryWord);

                    var httpResponse = await httpClient.GetAsync(url);

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var responseJson = await httpResponse.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<SearchResponse>(responseJson);
                    }
                    else 
                    {
                        string error = string.Format("Error occurred. Search action failed with status {0} for search word '{1}'", httpResponse.StatusCode, queryWord);
                        _logger.Error(error);
                        return SearchResponse.FromError(error);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return SearchResponse.FromException(ex);
            }
        }
    }
}
