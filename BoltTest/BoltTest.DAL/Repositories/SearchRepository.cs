using BoltTest.Core.Interfaces;
using BoltTest.DAL.DBObjects;
using BoltTest.DAL.Interfaces;
using BoltTest.Entities.Enums.Searches;
using BoltTest.Entities.Searches;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.DAL.Repositories
{
    internal class SearchRepository : DapperRepository, ISearchRepository
    {
        public SearchRepository(IConfiguration configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }

        public async Task<SearchResultItem> CreateAsync(SearchResultItem item)
        {
            try
            {
                using(var dbConnection = new SqlConnection(ConnectionString))
                {
                    var parameters = new 
                    {
                        Title = item.Title,
                        SearchEngineId = (int)item.SearchEngine,
                        EnteredDate = item.EnteredDate.ToString()
                    };

                    var dbItems = await dbConnection.QueryAsync<DbSearchResultItem>(
                           sql: "SearchResultsInsert",
                           param: parameters,
                           commandType: CommandType.StoredProcedure
                       );

                    var dbItem = dbItems.FirstOrDefault();
                    if(dbItem == null) 
                    {
                        return null;
                    }

                    return mapToEntity(dbItem);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        private SearchResultItem mapToEntity(DbSearchResultItem dbItem) 
        {
            var item = new SearchResultItem();
            item.Id = dbItem.Pkid;
            item.Title = dbItem.Title;
            item.EnteredDate = dbItem.EnteredDate;
            item.SearchEngine = (ESearchEngine)dbItem.SearchEngineId;
            return item;
        }
    }
}
