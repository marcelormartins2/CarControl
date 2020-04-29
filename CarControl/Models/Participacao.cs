using System;

namespace CarControl.Models
{
	public class Participacao
	{
		private double Porcentagem { get; set; }

		private double ParteLucro { get; set; }

		public Participacao()
		{

		}

		public Participacao(double porcentagem, double parteLucro)
		{
			Porcentagem = porcentagem;
			ParteLucro = parteLucro;
		}
	}

}