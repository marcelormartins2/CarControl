using System;

namespace CarControl.Models
{
	public class Responsavel
	{
		private double Porcentagem { get; set; }
		public Responsavel()
		{

		}

		public Responsavel(double porcentagem)
		{
			Porcentagem = porcentagem;
		}
	}

}