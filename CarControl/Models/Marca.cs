using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarControl.Models
{
	public class Marca
	{
		private string Nome { get; set; }

		private ICollection<Modelo> Modelo { get; set; } = new List<Modelo>();

		public Marca()
		{

		}

		public Marca(string nome, ICollection<Modelo> modelo)
		{
			Nome = nome;
			Modelo = modelo;
		}
	}
}
