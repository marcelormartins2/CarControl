using System;

namespace CarControl.Models
{
	public class Parceiro
	{
		public Guid Id { get; set; } = new Guid();

		public string Nome { get; set; }

		public string Email { get; set; }

		public string Telefone { get; set; }

		public string Endereço { get; set; }

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
}