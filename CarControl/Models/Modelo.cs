using System;
using System.Collections;
using System.Collections.Generic;

namespace CarControl.Models
{
	public class Modelo
	{
		public int Id { get; set; }
		public Marca Marca { get; set; }
		public int MarcaId { get; set; }
		private string Nome { get; set; }
		public ICollection<AnoModelo> AnoModelos { get; set; } = new List<AnoModelo>();

	}
}
