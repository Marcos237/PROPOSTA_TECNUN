using Tecnun.Dominio.Entidades.ValueObjects;
using Xunit;

namespace Tecnun_Testes.ValueObjects
{
    public class ValueObjects_Testes
    {

        [Fact(DisplayName = "Verificar se o CPF é inválido")]
        [Trait("Categoria", "Validar CPF")]
        public void DefinirCpfInvalido()
        {
            var cpf = "7069278306";

            Assert.False(CPF.Validar(cpf));
        }

        [Fact(DisplayName = "Verificar se o CPF é válido")]
        [Trait("Categoria", "Validar CPF")]
        public void DefinirCpfValido()
        {
            var cpf = new CPF("70692783067");

            Assert.True(CPF.Validar(cpf.Codigo));
        }
    }
}
