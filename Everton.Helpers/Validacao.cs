using System;

namespace Everton.Helpers
{
    public class Validacao
    {
        public static void ValidarId(string propName, Guid id)
        {
            ValidarId(id, propName + " id inválido!");
        }

        protected static void ValidarId(Guid id, string errorMessage)
        {
            if (id == Guid.Empty)
                throw new Exception(errorMessage);
        }

        public static void ValidarId(string propName, int id)
        {
            ValidarId(id, propName + " id inválido!");
        }

        public static void ValidarId(int id, string errorMessage)
        {
            if (!(id > 0))
                throw new Exception(errorMessage);
        }

        public static void ValidarNumeroNegativo(int number, string propName)
        {
            if (number < 0)
                throw new Exception(propName + " não pode ser negativo!");
        }

        public static void ValidarSeBrancoOuNuloMensagemPadrao(string value, string propName)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(propName + " é obrigatório!");
        }

        public static void ValidarSeBrancoOuNuloMensagem(string value, string errorMessage)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(errorMessage);
        }

        public static void ValidarTamanhoMaximoVariavel(string propName, string stringValue, int maximum)
        {
            ValidarTamanhoMaximoVariavel(stringValue, maximum, propName + " não pode ter mais que " + maximum + " caracteres");
        }

        public static void ValidarTamanhoMaximoVariavel(string stringValue, int maximum, string message)
        {
            int length = stringValue.Length;
            if (length > maximum)
            {
                throw new Exception(message);
            }
        }
        public static void ValidarTamanhoMinimoMaximoVariavel(string propName, string stringValue, int minimum, int maximum)
        {
            ValidarTamanhoMinimoMaximoVariavel(stringValue, minimum, maximum, propName + " deve ter de " + minimum + " à " + maximum + " caracteres!");
        }

        public static void ValidarTamanhoMinimoMaximoVariavel(string stringValue, int minimum, int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Length;
            if (length < minimum || length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void ValidarValoresIguais(string a, string b, string errorMessage)
        {
            if (a != b)
                throw new Exception(errorMessage);
        }
    }
}
