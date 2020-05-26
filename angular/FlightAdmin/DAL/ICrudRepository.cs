using System.Threading.Tasks;

namespace FlightAdmin.DAL
{
    public interface ICrudRepository<TEntity>
    {
         Task CreateAsync(TEntity entity);
    }
}