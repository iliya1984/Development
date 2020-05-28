using System.Threading.Tasks;

namespace FlightCrm.DAL.Interfaces
{
    public interface IUpdateRepository<TEntity>
    {
         Task<TEntity> UpdateAsync(TEntity entity);
    }
}