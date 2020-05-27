using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightCrm.DAL.Interfaces
{
    public interface IGetRepository<TEntity, TFilter>
    {
         Task<List<TEntity>> GetAsync(TFilter filter);
    }
}