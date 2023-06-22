using AloKaza.Core.Entities;
using AloKaza.MVCUI.Utils;
using AloKaza.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class NewsController : Controller
    {
        private readonly IService<News> _serviceNews;
        private readonly IService<AppLog> _serviceAppLog;

        public NewsController(IService<News> serviceNews, IService<AppLog> serviceAppLog)
        {
            _serviceNews = serviceNews;
            _serviceAppLog = serviceAppLog;
        }

        // GET: NewsController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _serviceNews.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.NewsController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(News collection, IFormFile? Image)
        {
            try
            {
                if (Image != null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                }
                await _serviceNews.AddAsync(collection);
                await _serviceNews.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Oluşturuldu...</div>";
                return RedirectToAction(nameof(Index), "News");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.NewsController.Create.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "News");
        }

        // GET: NewsController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "News");
                }
                var model = await _serviceNews.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "News");
                }


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.NewsController.Edit.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "News");
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, News collection, IFormFile? Image, bool? resmiSil)
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
                _serviceNews.Update(collection);
                await _serviceNews.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Güncellendi...</div>";
                return RedirectToAction(nameof(Index), "News");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.NewsController.Edit.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "News");
        }

        // GET: NewsController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "News");
                }
                var model = await _serviceNews.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "News");
                }


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.NewsController.Edit.Get",
                    Description = e.Message,
                    Details = e.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "News");
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, News collection)
        {
            try
            {
                if (collection.Image is not null)
                {
                    FileHelper.FileRemover(collection.Image);

                }
                _serviceNews.Delete(collection);
                await _serviceNews.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Silindi...</div>";

                return RedirectToAction(nameof(Index), "News");
            }
            catch (Exception e)
            {


                ModelState.AddModelError("", "Bir Hata Oluştu : " + e.Message);
                AppLog hata = new()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.NewsController.Delete.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "News");
        }
    }
}
        
