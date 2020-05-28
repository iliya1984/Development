using System.Threading.Tasks;

namespace FlightCrm.DAL.Interfaces
{
    public interface ICreateRepository<TEntity>
    {
         Task<TEntity> CreateAsync(TEntity entity);
    }
}