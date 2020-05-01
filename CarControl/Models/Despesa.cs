using System;

namespace CarControl.Models
{
	public class Despesa
	{
		public Guid Id { get; set; }

		public string Descricao { get; set; }

		public DateTime Data { get; set; }

		public double Valor { get; set; }

		public Despesa()
		{

		}

		public Despesa(string descricao, DateTime data, double valor)
		{
			Descricao = descricao;
			Data = data;
			Valor = valor;
		}
	}
}