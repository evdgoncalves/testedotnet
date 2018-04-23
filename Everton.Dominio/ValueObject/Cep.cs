using System;
using Everton.Helpers;

namespace Everton.Dominio.ValueObject
{
    public class Cep
    {
        public Int64? CepCod { get; private set; }
        public const int CepMaxLength = 8;

        protected Cep()
        {

        }

        public Cep(string cep)
        {
            Validacao.ValidarSeBrancoOuNuloMensagemPadrao(cep, "CEP");
            cep = TextoHelper.GetNumeros(cep);
            Validacao.ValidarTamanhoMaximoVariavel(cep, CepMaxLength, "CEP");
            try
            {
                CepCod = Convert.ToInt64(cep);
            }
            catch (Exception)
            {
                throw new Exception("Cep inválido: " + cep);
            }
        }

        public bool Vazio()
        {
            return !CepCod.HasValue;
        }

        public string GetCepFormatado()
        {
            if (CepCod == null)
                return "";

            var cep = CepCod.ToString();

            while (cep.Length < 8)
                cep = "0" + cep;

            return cep.Substring(0, 5) + "-" + cep.Substring(5);
        }
    }
}
