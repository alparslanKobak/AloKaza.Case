using AloKaza.Core.Entities;
using AloKaza.MVCUI.Models;
using AloKaza.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AloKaza.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Contact> _serviceContact;
        private readonly IService<AppLog> _serviceAppLog;
        private readonly IService<News> _serviceNews;
        private readonly IService<Slider> _serviceSlider;

        public HomeController(IService<Contact> serviceContact, IService<AppLog> serviceAppLog, IService<News> serviceNews, IService<Slider> serviceSlider)
        {
            _serviceContact = serviceContact;
            _serviceAppLog = serviceAppLog;
            _serviceNews = serviceNews;
            _serviceSlider = serviceSlider;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _serviceSlider.GetAllAsync(),
                News = await _serviceNews.GetAllAsync(n=> n.IsActive && n.IsHome)
                
               
            };
            return View(model);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}