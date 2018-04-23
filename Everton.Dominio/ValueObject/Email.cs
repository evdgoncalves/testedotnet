using System;
using System.Text.RegularExpressions;
using Everton.Helpers;

namespace Everton.Dominio.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public string Endereco { get; private set; }

        //Construtor do EntityFramework
        protected Email()
        {

        }

        public Email(string endereco)
        {
            Validacao.ValidarSeBrancoOuNuloMensagemPadrao(endereco, "E-mail");
            Validacao.ValidarTamanhoMaximoVariavel(endereco, EnderecoMaxLength, "E-mail");
            
            if(IsValid(endereco) == false)
                throw new Exception("E-mail inválido");

            Endereco = endereco;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
