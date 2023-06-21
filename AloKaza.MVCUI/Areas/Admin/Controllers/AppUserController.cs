using AloKaza.Core.Entities;
using AloKaza.MVCUI.Utils;
using AloKaza.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _serviceAppUser;
        private readonly IService<AppLog> _serviceAppLog;

        public AppUserController(IAppUserService serviceAppUser, IService<AppLog> serviceAppLog)
        {
            _serviceAppUser = serviceAppUser;
            _serviceAppLog = serviceAppLog;
        }

        // GET: AppUserController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _serviceAppUser.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppUserController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: AppUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppUser collection, IFormFile? Image)
        {
            try
            {
                if (Image != null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                }
                await _serviceAppUser.AddAsync(collection);
                await _serviceAppUser.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Oluşturuldu...</div>";
                return RedirectToAction(nameof(Index), "AppUser");
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppUserController.Create.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "AppUser");
        }

        // GET: AppUserController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "AppUser");
                }
                var model = await _serviceAppUser.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "AppUser");
                }


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppUserController.Edit.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "AppUser");
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AppUser collection, IFormFile? Image, bool? resmiSil)
        {
            try
            {
                if (resmiSil != null && collection.Image != null)
                {
                    FileHelper.FileRemover(collection.Image);
                    collection.Image = null;
                }

                if (Image != null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                }
                _serviceAppUser.Update(collection);
                await _serviceAppUser.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Güncellendi...</div>";
                return RedirectToAction(nameof(Index), "Slider");
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppUserController.Edit.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "AppUser");
        }

        // GET: AppUserController/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
        //            return RedirectToAction(nameof(Index), "AppUser");
        //        }
        //        var model = await _serviceAppUser.FindAsync(id.Value);

        //        if (model == null)
        //        {
        //            TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
        //            return RedirectToAction(nameof(Index), "AppUser");
        //        }


        //        return View(model);
        //    }
        //    catch (Exception e)
        //    {

        //        AppLog hata = new()
        //        {
        //            Title = "AloKaza.MVCUI.Areas.Admin.Controllers.AppUserController.Edit.Get",
        //            Description = e.Message,
        //            Details = e.InnerException.ToString()

        //        };
        //        TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

        //        await _serviceAppLog.AddAsync(hata);
        //        await _serviceAppLog.SaveAsync();
        //    }
        //    return RedirectToAction(nameof(Index), "AppUser");
        //}

        //// POST: AppUserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id, AppUser collection)
        //{
        //    try
        //    {
        //        if (collection.Image is not null)
        //        {
        //            FileHelper.FileRemover(collection.Image);

        //        }
        //        _serviceAppUser.Delete(collection);
        //        await _serviceAppUser.SaveAsync();
        //        TempData["Message"] = "<div class='alert alert-success'>Başarıyla Silindi...</div>";

        //        return RedirectToAction(nameof(Index), "Slider");
        //    }
        //    catch (Exception e)
        //    {


        //        ModelState.AddModelError("", "Bir Hata Oluştu : " + e.Message);
        //        AppLog hata = new()
        //        {
        //            Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Delete.Post",
        //            Description = e.Message,
        //            Details = e.InnerException.ToString()

        //        };
        //        TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

        //        await _serviceAppLog.AddAsync(hata);
        //        await _serviceAppLog.SaveAsync();
        //    }
        //    return RedirectToAction(nameof(Index), "AppUser");
        //}
    }
}
