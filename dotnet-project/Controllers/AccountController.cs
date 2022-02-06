using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotnet_project.Models;
using System.Web.Security;

namespace dotnet_project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var context = new UsuarioEntities())
            {
                bool isValid = context
                    .Users
                    .Any(x => x.nmLogin == user.nmLogin && x.dsSenha == user.dsSenha);

                var obj = context.Users.Where(x => x.nmLogin == user.nmLogin && x.dsSenha == user.dsSenha);

                if (isValid && obj != null)
                {
                    FormsAuthentication.SetAuthCookie(user.nmLogin, false);
                    Session["nmLogin"] = user.nmLogin;
                    return RedirectToAction("Index", "Usuarios");
                }

                ModelState.AddModelError("", "Usuário ou senha incorretos");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users user)
        {
            using (var context = new UsuarioEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}