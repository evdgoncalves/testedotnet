using Everton.Dominio.ValueObject;
using Everton.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Everton.Dominio.Entidade
{
    [Table("Usuario")]
    public class Usuario
    {
        #region "Constantes"
        public const int LoginMinLength = 6;
        public const int LoginMaxLength = 30;
        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;
        #endregion

        #region "Atributos"
        private int idUsuario;
        private string nomeUsuario;
        private long cpf;
        private string email;
        private string login;
        private DateTime? dataInclusao;
        #endregion

        #region "Propriedades"
        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        
        [Key]
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string NomeUsuario
        {
            get
            {
                return nomeUsuario;
            }

            set
            {
                nomeUsuario = value;
            }
        }

        public DateTime? DataInclusao
        {
            get
            {
                return dataInclusao;
            }

            set
            {
                dataInclusao = value;
            }
        }
        #endregion

        //Construtor EntityFramework
        public Usuario()
        {

        }

        public Usuario(string nome, string login, Cpf cpf)
        {
            NomeUsuario = nome;
            SetLogin(login);
            SetCpf(cpf);
            DataInclusao = DateTime.Now;
        }

        public void SetLogin(string login)
        {
            Validacao.ValidarSeBrancoOuNuloMensagemPadrao(login, "Login");
            Validacao.ValidarTamanhoMinimoMaximoVariavel(login, LoginMinLength, LoginMaxLength, "Login");
            Login = login;
        }

        public void SetCpf(Cpf cpf)
        {
            if (cpf == null)
                throw new Exception("Cpf Obrigatório");
            Cpf = cpf.Codigo;
        }
    }
}
