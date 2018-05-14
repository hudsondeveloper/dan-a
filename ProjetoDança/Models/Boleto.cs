using ControleEstoque.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDança.Models
{
	public class Boleto
	{
		public int Id { get; set; }
		public string MesBoleto { get; set; }
		public int pago { get; set; }
		public int alunoId { get; set; }

	}
}