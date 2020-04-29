using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Fabricante
{
	private string Nome { get; set; }

	private string Site { get; set; }

	private ICollection<Marca> Marca { get; set; } = new List<Marca>();
	public Fabricante()
	{

	}

}

