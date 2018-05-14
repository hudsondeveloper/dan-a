using ProjetoDança.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDança.Controllers
{
	public class BoletoController : Controller
	{
		[Authorize]
		public ActionResult Boleto()
		{
			//Cria o obj cookie e recebe o mesmo pelo obj Request

			HttpCookie cookie = Request.Cookies["usuario"];

			//Imprime o valor do cookie

		

			ViewBag.Title = "Dança";
			string sql = string.Format("Select * from Boleto where idAluno =(select id from usuario where login like '{0}')", cookie.Value.ToString());
			using (var conn = new SqlConnection(@"Data Source=DESKTOP-KCRACR9\SQLExpress;initial catalog=controle-estoque;User id=sa;Password=starwark11"))
			{
				var cmd = new SqlCommand(sql, conn);
				List<Boleto> list = new List<Boleto>();
				Boleto p = null;
				try
				{
					conn.Open();
					using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (reader.Read())
						{
							p = new Boleto();
							p.Id = int.Parse(reader["id"].ToString());
							p.MesBoleto = reader["mesBoleto"].ToString();
							p.pago = int.Parse(reader["pago"].ToString());
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