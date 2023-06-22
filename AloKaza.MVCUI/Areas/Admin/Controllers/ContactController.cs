using AloKaza.Core.Entities;
using AloKaza.Service.Abstract;
using AloKaza.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AloKaza.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ContactController : Controller
    {
        private readonly IService<Contact> _serviceContact;
        private readonly IService<AppLog> _serviceAppLog;

        public ContactController(IService<Contact> serviceContact, IService<AppLog> serviceAppLog)
        {
            _serviceContact = serviceContact;
            _serviceAppLog = serviceAppLog;
        }

        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _serviceContact.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ContactController.Index",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Main");
        }

        // GET: ContactController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Contact");
                }
                var model = await _serviceContact.FindAsync(id.Value);

                if (model == null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";
                    return RedirectToAction(nameof(Index), "Contact");
                }

                return View(model);
            }
            catch (Exception e)
            {

                AppLog hata = new AppLog()
                {
                    Title = "AloKaza.MVCUI.Areas.Admin.Controllers.ContactController.Details",
                    Description = e.Message,
                    Details = e.InnerException.ToString()

                };
                TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu... </div>";

                await _serviceAppLog.AddAsync(hata);
                await _serviceAppLog.SaveAsync();
            }
            return RedirectToAction(nameof(Index), "Contact");
        }

        // Contact işlemi, önyüz üzerinden bize gönderilecek ve listeleyeceğiz...

        //// GET: ContactController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ContactController/Create
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

        //// GET: ContactController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ContactController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
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

        //// GET: ContactController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ContactController/Delete/5
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
