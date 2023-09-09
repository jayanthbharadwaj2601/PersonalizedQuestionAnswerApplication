using IssueTrackingSystem.Data;
using IssueTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace IssueTrackingSystem.Controllers
{
    public class AdminController : Controller
    {
        public readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin obj)
        {
            obj.count = 0;
            List<Admin> e=_db.Admin.ToList();
            int c = 0;
            foreach(Admin i in e)
            {
                if(i.Name==obj.Name)
                {
                    c += 1;
                    break;
                }
            }
            if (c > 0)
            {
                return RedirectToAction("AlreadyExists");
            }
            else
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AlreadyExists()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin obj) {
            var e = _db.Admin.ToList();
            int c = 0;
            foreach(Admin i in e)
            {
                if(i.Name==obj.Name && i.password==obj.password)
                {
                    c += 1;
                    break;
                }
            }
            if(c==0)
            {
                return RedirectToAction("NotFound");
            }
            else
            {
                return RedirectToAction("Homepage", obj);
            }
        }
        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Homepage(Admin obj)
        {
            var e = _db.Issues.ToList();
            List<Solutions> g=new List<Solutions>();
            foreach(Issues i in e)
            {
                Solutions h = new Solutions();
                h.Customer = i.username;
                h.Admin = obj.Name;
                h.Issue = i.issue;
                h.IssueId = i.Id;
                h.Solution = "Hello";
                g.Add(h);
            }
            return View(g);
        }
        public IActionResult ProvideSolution(Solutions ? obj)
        {
            return View(obj); 
        
        }

        [HttpPost]
        public IActionResult ProvideSolution1(Solutions obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return View();
        }

    }
}
