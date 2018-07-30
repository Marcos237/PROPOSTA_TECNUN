using Tecnun.Dominio.Helpers;

namespace Tecnun.Dominio.Entidades.ValueObjects
{
    public class TELEFONE
    {
        public string Numero { get; private set; }

        public TELEFONE()
        {

        }

        public TELEFONE(string numero)
        {
            Numero = ValidarTelefone(numero);
        }

        public static string ValidarTelefone(string numero)
        {
            var semmascara = TextoHelper.GetNumeros(numero);
            return semmascara;

        }
    }
}
