using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MyBread.Db;
using MyBread.Models;

namespace MyBread.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    [Route("/aboba")]
    public IActionResult aboba()
    {
        ViewBag.Countries = new List<string> { "Бразилия", "Аргентина", "Уругвай", "Чили" };
        return View();
    }
    
    [HttpGet]
    [Route("/")]
    public IActionResult main()
    {
        return View();
    }
    [HttpGet]
    [Route("/products")]
    public IActionResult products()
    {
        return View();
    }
    [HttpGet]
    [Route("/ordering")]
    public IActionResult ordering()
    {
        ProductData data = new ProductData();
        ViewBag.Products = data.FindAll();
        
        // bool success = false;
        // if (success)
        //     ViewData["success"] = "Успешно";
        // else
        //     ViewData["success"] = "Ошибка";
        return View();
    }
    [HttpPost]
    [Route("/ordering")]
    public IActionResult ordering([FromBody] OrderReqBody orderReqBody) {
        Console.WriteLine(orderReqBody.ToString());
        // IEnumerable<int> quantity = new IEnumerable<>();
        // for (Hashtable<String, String> data : requestDataList) {
        //     quantity += int.Parse(data["quantity"]);
        //
        // }
        // ProductData.updateQuantityAll(quantity);
        return Redirect("/?error");
    }
    [HttpPost]
    [Route("/login")]
    public IActionResult login([FromForm] AuthReqBody authReqBody)
    {
        UserData userData = new UserData();
        User user = userData.FindByLogin(authReqBody.Login);
        if ( user!= null && user.Password==authReqBody.Password)
        {
            Response.Cookies.Append("cyxaruk", user.Login, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1) // Например, устанавливаем срок действия на 1 день
            });
            return Redirect("/profile");
        }

        return Redirect("/?error");
    }
    [HttpGet]
    [Route("/profile")]
    public IActionResult profile()
    {
        
        return View();
    }
    [HttpGet]
    [Route("/logout")]
    public IActionResult logout()
    {
        return Redirect("/");
    }

    [HttpPost]
    [Route("/signup")]
    public IActionResult signup([FromForm] AuthReqBody authReqBody)
    {
        UserData userData = new UserData();
        if (userData.FindByLogin(authReqBody.Login) == null)
        {
            User newUser = new User();
            newUser.Login = authReqBody.Login;
            newUser.Password = authReqBody.Password;
            userData.Save(newUser);
            Response.Cookies.Append("cyxaruk", newUser.Login, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1) // Например, устанавливаем срок действия на 1 день
            });
            return Redirect("/profile");
        }
        return Redirect("/?error");
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}