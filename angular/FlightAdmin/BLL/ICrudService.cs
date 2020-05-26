using System.Threading.Tasks;

namespace FlightAdmin.BLL
{
    public interface ICrudService<TEntity>
    {
         Task CreateAsync(TEntity entity);
    }
}