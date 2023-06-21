using AloKaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data.Abstract
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<Report> GetReportByIncludeAsync(int id);

        Task<List<Report>> GetAllReportsByIncludeAsync();

        Task<List<Report>> GetAllReportsByIncludeAsync(Expression<Func<Report,bool>> expression);


    }
}
