using System;

namespace CarControl.Models
{
	public class Participacao
	{
		public Parceiro Parceiro{ get; set; }
		public int ParceiroId { get; set; }
		public double Porcentagem { get; set; }

		public double ParteLucro { get; set; }

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