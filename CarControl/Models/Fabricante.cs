using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarControl.Models
{
	public class Fabricante
	{
		public int Id { get; set; }
		public string Nome { get; set; }

		public string Site { get; set; }

		public int Prioridade { get; set; }

		public ICollection<ModeloCar> ModeloCar { get; set; } = new List<ModeloCar>();
		//public Fabricante()
		//{

		//}

		//public Fabricante(int id, string nome, string site)
		//{
		//	Id = id;
		//	Nome = nome;
		//	Site = site;
		//}
	}
}
