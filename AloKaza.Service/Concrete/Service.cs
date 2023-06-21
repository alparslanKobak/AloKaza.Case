using AloKaza.Core.Entities;
using AloKaza.Data;
using AloKaza.Data.Concrete;
using AloKaza.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AloKaza.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {

        }
    }
}
