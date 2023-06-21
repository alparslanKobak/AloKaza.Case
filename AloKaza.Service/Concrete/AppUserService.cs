using AloKaza.Core.Entities;
using AloKaza.Data;
using AloKaza.Data.Concrete;
using AloKaza.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Service.Concrete
{
    public class AppUserService : AppUserRepository, IAppUserService
    {
        public AppUserService(DatabaseContext context) : base(context)
        {
        }
    }
}
