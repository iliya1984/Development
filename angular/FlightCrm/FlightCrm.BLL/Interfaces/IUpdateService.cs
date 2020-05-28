using System.Threading.Tasks;

namespace  FlightCrm.BLL.Interfaces
{
    public interface IUpdateService<TEntity>
    {
         Task<TEntity> UpdateAsync(TEntity entity);
    }
}