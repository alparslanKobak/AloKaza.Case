using AloKaza.Core.Entities;
using AloKaza.MVCUI.Utils;
using AloKaza.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SettingsController : Controller
    {
        private readonly IService<Setting> _serviceSettings;
        private readonly IService<AppLog> _serviceAppLog;

        public SettingsController(IService<Setting> serviceSettings, IService<AppLog> serviceAppLog)
        {
            _serviceSettings = serviceSettings;
            _serviceAppLog = serviceAppLog;
        }

        // GET: SettingsController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _serviceSettings.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SettingsController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: SettingsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SettingsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: SettingsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: SettingsController/Edit/5


        // Projenin Çökmemesi için, ayarların silinememesi ve yeni oluşturulamaması gerekir. Yalnızca yeniden düzenlenecektir.
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Settings");
                }
                var model = await _serviceSettings.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Settings");
                }


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SettingsController.Edit.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Settings");
        }

        // POST: SettingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Setting collection, IFormFile? Logo, IFormFile? Favicon)
        {
            try
            {
                if (Favicon != null)
                {
                    collection.Favicon = await FileHelper.FileLoaderAsync(Favicon);
                }

                if (Logo != null)
                {
                    collection.Logo = await FileHelper.FileLoaderAsync(Logo);
                }
                 _serviceSettings.Update(collection);
                await _serviceSettings.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Güncellendi...</div>";
                return RedirectToAction(nameof(Index), "Settings");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SettingsController.Edit.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Settings");
        }

        // GET: SettingsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: SettingsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
