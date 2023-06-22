using AloKaza.Core.Entities;
using AloKaza.MVCUI.Utils;
using AloKaza.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ReportController : Controller
    {
        private readonly IReportService _serviceReport;
        private readonly IService<AppLog> _serviceAppLog;
        private readonly IAppUserService _serviceAppUser;

        public ReportController(IReportService serviceReport, IService<AppLog> serviceAppLog, IAppUserService serviceAppUser)
        {
            _serviceReport = serviceReport;
            _serviceAppLog = serviceAppLog;
            _serviceAppUser = serviceAppUser;
        }

        // GET: ReportController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _serviceReport.GetAllReportsByIncludeAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ReportController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: ReportController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Report");
                }
                var model = await _serviceReport.GetReportByIncludeAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Report");
                }


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ReportController.Details.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Report");
        }

        // GET: ReportController/Create
        public async Task<ActionResult> Create()
        {
           
            return View();
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Report collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _serviceReport.AddAsync(collection);
                    await _serviceReport.SaveAsync();
                    TempData["Message"] = "<div class='alert alert-success'>Başarıyla Oluşturuldu...</div>";

                }

                return RedirectToAction(nameof(Index), "Report");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ReportController.Create.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            ViewBag.AppUserId = new SelectList(await _serviceAppUser.GetAllAsync(), "Id", "Name");
            return RedirectToAction(nameof(Index), "Report");
        }

        // GET: ReportController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Report");
                }
                var model = await _serviceReport.GetReportByIncludeAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Report");
                }
                ViewBag.AppUserId = new SelectList(await _serviceAppUser.GetAllAsync(), "Id", "Name");


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ReportController.Edit.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Report");
        }

        // POST: ReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Report collection)
        {
            try
            {

                _serviceReport.Update(collection);
                await _serviceReport.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Güncellendi...</div>";
                return RedirectToAction(nameof(Index), "Report");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ReportController.Edit.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Report");

        }

        // GET: ReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
