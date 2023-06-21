using AloKaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data.Abstract
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetAppUserByIncludeAsync(int id);
    }
}
