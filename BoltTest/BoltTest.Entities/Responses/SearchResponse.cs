using BoltTest.Core.ErrorHandling;
using BoltTest.Entities.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Entities.Responses
{
    public class SearchResponse : BaseResponse
    {
        public string QueryWord { get; set; }
        public List<SearchResultItem> Results { get; set; }

        public SearchResponse()
        {
            Results = new List<SearchResultItem>();
        }

        public static SearchResponse FromException(Exception ex) 
        {
            var response = new SearchResponse();
            response.AddError(new Error 
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            });

            return response;
        }

        public static SearchResponse FromError(string errorMessage)
        {
            var response = new SearchResponse();
            response.AddError(new Error
            {
                Message = errorMessage
            });

            return response;
        }
    }
}
