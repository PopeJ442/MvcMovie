using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name,int age = 4)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["age"] = age;
        return View();
    }
}