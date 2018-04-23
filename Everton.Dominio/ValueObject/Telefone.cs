using Everton.Helpers;

namespace Everton.Dominio.ValueObject
{
    public class Telefone
    {
        public const int NumeroMaxLength = 20;
        public string Numero { get; private set; }

        public const int DDDMaxLength = 3;
        public string DDD { get; private set; }

        protected Telefone()
        {

        }

        public Telefone(string ddd, string numero)
        {
            SetTelefone(numero);
            SetDDD(ddd);
        }

        private void SetTelefone(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                numero = "";
            else
                Validacao.ValidarTamanhoMaximoVariavel(numero, NumeroMaxLength, "Telefone");
            Numero = numero;
        }

        private void SetDDD(string ddd)
        {
            if (string.IsNullOrEmpty(ddd))
                ddd = "";
            else
                Validacao.ValidarTamanhoMaximoVariavel(ddd, DDDMaxLength, "DDD");
            DDD = ddd;
        }

        public string GetTelefoneCompleto()
        {
            return DDD + Numero;
        }
    }
}
