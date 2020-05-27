using System.Threading.Tasks;

namespace FlightCrm.BLL.Interfaces
{
    public interface ICreateService<TEntity>
    {
         Task<TEntity> CreateAsync(TEntity entity);
    }
}