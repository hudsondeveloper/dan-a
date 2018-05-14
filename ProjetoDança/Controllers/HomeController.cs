using ControleEstoque.web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDança.Controllers
{

	public class HomeController : Controller
	{
		[Authorize]
		public ActionResult Index()
		{
			ViewBag.Title = "Dança";
			string sql = "Select * from usuario";
			using (var conn = new SqlConnection(@"Data Source=DESKTOP-KCRACR9\SQLExpress;initial catalog=controle-estoque;User id=sa;Password=starwark11"))
			{
				var cmd = new SqlCommand(sql, conn);
				List<LoginViewModel> list = new List<LoginViewModel>();
				LoginViewModel p = null;
				try
				{
					conn.Open();
					using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (reader.Read())
						{
							p = new LoginViewModel();
							p.Id = int.Parse(reader["id"].ToString());
							p.Nome = reader["login"].ToString();
							p.Senha = reader["senha"].ToString();
							list.Add(p);
						}
					}
				}
				catch (Exception e)
				{
					throw e;
				}
				return View(list);
			}

		}

	}
}