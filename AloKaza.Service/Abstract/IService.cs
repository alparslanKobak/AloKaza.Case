using AloKaza.Core.Entities;
using AloKaza.Data.Abstract;

namespace AloKaza.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {

    }
}
