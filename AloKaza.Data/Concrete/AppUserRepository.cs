using AloKaza.Core.Entities;
using AloKaza.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data.Concrete
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DatabaseContext context, DbSet<AppUser> dbSet) : base(context)
        {
        }

        public Task<AppUser> GetAppUserByIncludeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
