using System;
using System.Collections;
using System.Collections.Generic;

namespace CarControl.Models
{
	public class Modelo
	{
		private string Nome { get; set; }
		private ICollection<AnoModelo> AnoModelo { get; set; } = new List<AnoModelo>();
		public Modelo()
		{

		}

		public Modelo(string nome)
		{
			Nome = nome;
		}
	}
}
