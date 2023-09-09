using IssueTrackingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using IssueTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace IssueTrackingSystem.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(Customer obj)
        {
            try
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception exception)
            {
                return RedirectToAction("AlreadyExists", "Admin");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Customer obj)
        {
            var d = _db.Customers.ToList();
            int c1 = 0;
            foreach(Customer i in d)
            {
                if (i.Name == obj.Name && i.Password==obj.Password)
                    c1 += 1;
            }
            if (c1==0) { return RedirectToAction("NotFound"); }
            else
                return RedirectToAction("HomePage",obj);
        }
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult HomePage(Customer obj)
        {
            List<Issues> g = _db.Issues.ToList();
            List<Issues> h = new List<Issues>();
            foreach(Issues i in g)
            {
                if (i.username == obj.Name)
                    h.Add(i);
            }
            return View(h);
        }
        public IActionResult AddIssue()
        {
            Issues e = new Issues();
            e.Solution = "Not yet Covered";
            //Console.WriteLine(e.username + " " + e.issue + " " + e.Solution + " " + e.Id);
            return View(e);
        }
        [HttpPost]
        public IActionResult AddIssue(Issues e)
        {
            _db.Add(e);
            _db.SaveChanges();
            var f = _db.Customers.ToList();
            Customer g =new Customer();
            //Console.WriteLine(e.username + " " + e.issue + " " + e.Solution + " " + e.Id);
            foreach (Customer i in f)
            {
                if(i.Name==e.username)
                {
                    g = i;
                    break;
                }
            }
            return RedirectToAction("HomePage",g);
        }

        public IActionResult viewresponses(int ? obj)
        {
            List<Solutions> g=new List<Solutions>();
            List<Solutions> f = _db.Solutions.ToList();
            String username = "";
            foreach(Solutions i in  f)
            {
                if(i.IssueId==obj)
                {
                    g.Add(i);
                    username = i.Customer;
                }
            }
            if(g.Count()!=0)
            return View(g);
            else
            {
                return RedirectToAction("NoSolsFound");
                
            }
        }
        public IActionResult NoSolsFound()
        {
            return View();
        }
        public IActionResult returnToHomePage(String obj)
        {
            List<Customer> g = _db.Customers.ToList();
            Customer h =new Customer();
            foreach(Customer i in g)
            {
                if (i.Name == obj)
                    h = i;
            }
            return RedirectToAction("HomePage", h);
        }

    }
}
