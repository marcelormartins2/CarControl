using System;

public class Parceiro
{
	private Guid Id { get; set; } = new Guid();

	private string Nome { get; set; }

	private string Email { get; set; }

	private string Telefone { get; set; }

	private string Endereço { get; set; }

	public Parceiro()
	{

	}

	public Parceiro(string nome, string email, string telefone, string endereço)
	{
		Nome = nome;
		Email = email;
		Telefone = telefone;
		Endereço = endereço;
	}
}
