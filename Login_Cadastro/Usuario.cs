using System;

namespace DataShift.Login_Cadastro
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; } // Primeira letra Maiúscula
        public string Senha { get; set; } // Primeira letra Maiúscula

        public Usuario() { }

        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }
    }
}