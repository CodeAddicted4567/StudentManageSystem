using StudentMng.Contracts;
using StudentMng.Areas.Users.Data;
using System.Web.Mvc;

namespace StudentMng.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        public AccountController(IUserService _service)
        {
            userService = _service;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                userService.CreateUser(user);
                TempData["Success"] = "User registered";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            //var CheckAuth = userService.IsValidate(user.UserName, user.Password);
            var userData = userService.Authenticate(user);
            if (userData != null)
            {
                Session["User"] = userData.Value.username;
                Session["Role"] = userData.Value.role;

                if (userData.Value.role == "Admin")
                {
                    return RedirectToAction("AdminProfile", "Dashboard");
                }
                else if (userData.Value.role == "User")
                {
                    return RedirectToAction("UserProfile", "Dashboard");
                }
            }
            else
            {
                TempData["Fail"] = "Wrong credentials";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
        }
    }
}
