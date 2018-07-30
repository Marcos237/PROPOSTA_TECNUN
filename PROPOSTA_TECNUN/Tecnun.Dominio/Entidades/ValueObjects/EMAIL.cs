using System.Text.RegularExpressions;

namespace Tecnun.Dominio.Entidades.ValueObjects
{
    public class EMAIL
    {
        public string Endereco { get; private set; }

        protected EMAIL()
        {

        }

        public EMAIL(string endereco)
        {
            ValidarEmail(endereco);
        }

        public string ValidarEmail(string email)
        {
            if (IsValid(email))
                Endereco = email;
            return Endereco;
        }

        public static bool IsValid(string endereco)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(endereco);
        }
    }
}