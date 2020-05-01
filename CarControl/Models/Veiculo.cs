using System;
using System.Collections.Generic;

namespace CarControl.Models
{
	public class Veiculo
	{
		public Guid Id { get; set; }
		public Modelo Modelo { get; set; }
		public int ModeloId { get; set; }
		public String Placa { get; set; }
		public string Chassis { get; set; }
		public int Hodometro { get; set; }
		public string Cor { get; set; }
		public DateTime AnoFab { get; set; }
		public DateTime AnoModelo { get; set; }
		public string Origem { get; set; }
		public int Renavam { get; set; }
		public double ValorFipe { get; set; }
		public double ValorPago { get; set; }
		public double ValorVenda { get; set; }
		public Fabricante Fabricante { get; set; }

		public Veiculo()
		{
			this.Id = new Guid();
		}

		public Veiculo(Modelo modelo, int modeloId, string placa, string chassis, int hodometro, string cor, DateTime anoFab, DateTime anoModelo, string origem, int renavam, double valorFipe, double valorPago, double valorVenda, Fabricante fabricante)
		{
			this.Id = new Guid();
			Modelo = modelo;
			ModeloId = modeloId;
			Placa = placa;
			Chassis = chassis;
			Hodometro = hodometro;
			Cor = cor;
			AnoFab = anoFab;
			AnoModelo = anoModelo;
			Origem = origem;
			Renavam = renavam;
			ValorFipe = valorFipe;
			ValorPago = valorPago;
			ValorVenda = valorVenda;
			Fabricante = fabricante;
		}
	}
}