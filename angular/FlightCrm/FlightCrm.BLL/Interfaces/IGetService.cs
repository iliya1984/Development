using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightCrm.BLL.Interfaces
{
    public interface IGetService<TEntity, TFilter>
    {
         Task<List<TEntity>> GetAsync(TFilter filter);
    }
}