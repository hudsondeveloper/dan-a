using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.web.Models
{
	public class LoginViewModel
	{

		public int Id { get; set; }
		[Required(ErrorMessage ="campo Usuário é obrigatorio")]
		[Display(Name="Usuário")]
		public string Nome { get; set; }
		[Required(ErrorMessage = "campo Senha é obrigatorio")]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Senha { get; set; }
		[Display(Name = "Lembrar-me")]
		public bool LembarMe { get; set; }



	}
}