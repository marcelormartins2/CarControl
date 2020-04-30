using System;
using System.Collections.Generic;

namespace CarControl.Models
{
	public class Veiculo
	{
		private Guid Id { get; set; }

		public ICollection<AnoModelo> AnoModelo { get; set; } = new List<AnoModelo>();
		public int AnoModeloId { get; set; }

		private int Placa { get; set; }

		private string Chassis { get; set; }

		private string Cor { get; set; }

		private DateTime AnoFab { get; set; }

		private string Origem { get; set; }

		private int Renavam { get; set; }

		private double ValorPago { get; set; }

		private double ValorVenda { get; set; }

		private Fabricante Fabricante { get; set; }

		public Veiculo()
		{
			this.Id = new Guid();
		}
		public Veiculo(int anoModeloId, int placa, string chassis, string cor, DateTime anoFab, string origem, int renavam, double valorPago, double valorVenda, Fabricante fabricante)
		{
			this.Id = new Guid();
			AnoModeloId = anoModeloId;
			Placa = placa;
			Chassis = chassis;
			Cor = cor;
			AnoFab = anoFab;
			Origem = origem;
			Renavam = renavam;
			ValorPago = valorPago;
			ValorVenda = valorVenda;
			Fabricante = fabricante;
		}
	}
}