using System;
using System.Collections;
using System.Collections.Generic;

namespace CarControl.Models
{
	public class ModeloCar
	{
		public int Id { get; set; }
		public Fabricante Fabricante { get; set; }
		public int FabricanteId { get; set; }
		public string Nome { get; set; }

	}
}
