using AjaxHomeWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxHomeWork.Controllers
{
    public class apiController : Controller
    {
        private readonly DemoContext _db;
        public apiController(DemoContext db)
        {
          
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
            public IActionResult name(string name)
            {
            if (name == null)
                return Content($"請輸入姓名", "text/plain", System.Text.Encoding.UTF8);
            var _name = _db.Members.FirstOrDefault(m => m.Name == name);
            if (_name == null)
            return Content($"{name}可以使用", "text/plain", System.Text.Encoding.UTF8);
            return Content($"{name}已被註冊過","text/plain",System.Text.Encoding.UTF8);
            }
        public IActionResult city()
        {
            var _city = _db.Addresses.Select(c => c.City).Distinct();
            return Json(_city);
        }
        public IActionResult Site(string city)
        {
            var _site = _db.Addresses.Where(s=>s.City==city).Select(s=>s.SiteId).Distinct();
            return Json(_site);
        }
        public IActionResult Road(string site)
        {
            var _road = _db.Addresses.Where(r => r.SiteId == site).Select(r => r.Road).Distinct();
            return Json(_road);
        }
    }
}
