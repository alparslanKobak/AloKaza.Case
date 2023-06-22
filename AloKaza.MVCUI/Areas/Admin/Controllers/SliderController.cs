using AloKaza.Core.Entities;
using AloKaza.MVCUI.Utils;
using AloKaza.Service.Abstract;
using AloKaza.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SliderController : Controller
    {
        private readonly IService<Slider> _serviceSlider;
        private readonly IService<AppLog> _serviceAppLog;

        public SliderController(IService<Slider> serviceSlider, IService<AppLog> serviceAppLog)
        {
            _serviceSlider = serviceSlider;
            _serviceAppLog = serviceAppLog;
        }

        // GET: SliderController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _serviceSlider.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: SliderController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slider collection, IFormFile? Image)
        {
            try
            {
                if (Image != null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                }
                await _serviceSlider.AddAsync(collection);
                await _serviceSlider.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Oluşturuldu...</div>";
                return RedirectToAction(nameof(Index), "Slider");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Create.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Slider");
        }

        // GET: SliderController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Slider");
                }
                var model = await _serviceSlider.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Slider");
                }


                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Edit.Get",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Slider");
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Slider collection, IFormFile? Image, bool? resmiSil)
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
                _serviceSlider.Update(collection);
                await _serviceSlider.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Güncellendi...</div>";
                return RedirectToAction(nameof(Index), "Slider");
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Edit.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Slider");
        }

        // GET: SliderController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Slider");
                }
                var model = await _serviceSlider.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Slider");
                }


                return View(model);
            }
            catch (Exception e)
            {

                //AppLog hata = new()
                //{
                //    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Delete.Get",
                //    Description = e.Message,
                //    Details = e.InnerException.ToString()

                //};
                //TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                //await _serviceAppLog.AddAsync(hata);
                //await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Slider");
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Slider collection)
        {
            try
            {
                if (collection.Image is not null)
                {
                    FileHelper.FileRemover(collection.Image);

                }
                _serviceSlider.Delete(collection);
                await _serviceSlider.SaveAsync();
                TempData["Message"] = "<div class='alert alert-success'>Başarıyla Silindi...</div>";

                return RedirectToAction(nameof(Index), "Slider");
            }
            catch (Exception e)
            {


                ModelState.AddModelError("","Bir Hata Oluştu : " + e.Message);
                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.SliderController.Delete.Post",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Slider");
        }
    }
}
