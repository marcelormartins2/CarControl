using System;

public class Despesa
{
	private Guid Id { get; set; } = new Guid();

	private string Descricao { get; set; }

	private DateTime Data { get; set; }

	private double Valor { get; set; }

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

