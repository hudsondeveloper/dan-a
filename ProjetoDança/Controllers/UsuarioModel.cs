using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.web.Models
{
	public class UsuarioModel
	{
		public static bool validarUsuario(string nome, string senha)
		{
			var ret = false;
			using (var conexao = new SqlConnection())
			{
				conexao.ConnectionString = @"Data Source=DESKTOP-KCRACR9\SQLExpress;initial catalog=controle-estoque;User id=sa;Password=starwark11";
				conexao.Open();
				using (var comando = new SqlCommand())
				{
					comando.Connection = conexao;
					comando.CommandText =
						string.Format("select count(*) from dbo.usuario where login = '{0}' and senha = '{1}'", nome, senha);
					ret = ((int)comando.ExecuteScalar()) > 0;
				}
			}
			return ret;
		}


	}
}