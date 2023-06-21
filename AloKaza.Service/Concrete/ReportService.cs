using AloKaza.Data;
using AloKaza.Data.Concrete;
using AloKaza.Service.Abstract;

namespace AloKaza.Service.Concrete
{
    public class ReportService : ReportRepository, IReportService
    {
        public ReportService(DatabaseContext context) : base(context)
        {
        }
    }
}
