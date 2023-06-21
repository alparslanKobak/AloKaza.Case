using AloKaza.Core.Entities;
using AloKaza.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AloKaza.Data.Concrete
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Report> GetReportByIncludeAsync(int id)
        {
            return await _context.Reports.Include(r=> r.AppUser).Include(r=> r.DamageRecords).FirstOrDefaultAsync(r=> r.Id == id);
        }

        public async Task<List<Report>> GetAllReportsByIncludeAsync()
        {
            return await _context.Reports.Include(r=> r.AppUser).Include(r=> r.DamageRecords).ToListAsync();
        }

        public async Task<List<Report>> GetAllReportsByIncludeAsync(Expression<Func<Report, bool>> expression)
        {
            return await _context.Reports.Where(expression).Include(x => x.AppUser).Include(x => x.DamageRecords).ToListAsync();
        }

    }
}
