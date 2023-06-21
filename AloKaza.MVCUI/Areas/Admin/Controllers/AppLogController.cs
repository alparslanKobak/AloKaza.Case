using AloKaza.Core.Entities;
using AloKaza.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppLogController : Controller
    {
        private readonly IService<AppLog> _service;

        public AppLogController(IService<AppLog> service)
        {
            _service = service;
        }

        // GET: AppLogController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _service.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppLogController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _service.AddAsync(hata);
                await _service.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: AppLogController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "AppLog");
                }
                var model = await _service.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "AppLog");
                }

                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppLogController.Details",
                    Description = e.Message,
                    Details = e.InnerException.ToString()
                    
                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _service.AddAsync(hata);
                await _service.SaveAsync();
            }
            return RedirectToAction(nameof(Index),"AppLog");
        }

        // Hata kayıtlarının otomatik ve site tarafından oluşturulması gerekir...

        // GET: AppLogController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AppLogController/Create
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

        // GET: AppLogController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "AppLog");
                }
                var model = await _service.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "AppLog");
                }

                return View(model);

            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppLogController.Edit.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _service.AddAsync(hata);
                await _service.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "AppLog");
        }

        // POST: AppLogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AppLog collection)
        {
            try
            {
                _service.Update(collection);
                await _service.SaveAsync();
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppLogController.Edit.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _service.AddAsync(hata);
                await _service.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "AppLog");
        }

        // GET: AppLogController/Delete/5

        // Hata kayıtları silinmesin, yalnızca çözüldüğü ve nasıl çözüldüğü gözüksün...

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AppLogController/Delete/5
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
