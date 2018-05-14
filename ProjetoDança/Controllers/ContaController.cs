using ControleEstoque.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleEstoque.web.Controllers
{
    public class ContaController : Controller
    {
		[AllowAnonymous]
        public ActionResult Login(String returnUrl)
        {
			ViewBag.ReturnUrl = returnUrl;
			return View();
        }

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(LoginViewModel login,string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(login);
			}

			var achou = UsuarioModel.validarUsuario(login.Nome,login.Senha );

			if (achou)
			{
				HttpCookie cookie = new HttpCookie("Usuario");

				//Define o valor do cookie

				cookie.Value = login.Nome;

				//Time para expiração (1min)

				DateTime dtNow = DateTime.Now;

				TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);

				cookie.Expires = dtNow + tsMinute;

				//Adiciona o cookie

				Response.Cookies.Add(cookie);

				FormsAuthentication.SetAuthCookie(login.Nome, login.LembarMe);
				if (Url.IsLocalUrl(returnUrl))
				{
					return Redirect(returnUrl);
				}
				else
				{
					RedirectToAction("Index", "Home");
				}
			}
			else
			{
				ModelState.AddModelError("", "Login invalido");
			}
			return View(login);
		}

		[HttpGet]
		[Authorize]
		public ActionResult Logoff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
    }

}