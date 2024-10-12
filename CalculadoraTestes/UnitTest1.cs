using System;
using Xunit;
using Calculadora;

namespace CalculadoraTestes
{
    public class UnitTest1
    {
        CalculadoraImp calc = new CalculadoraImp();
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int num1, int num2, int resultado)
        {
            int resultadoCalculadora = calc.somar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora); 
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int num1, int num2, int resultado)
        {
            int resultadoCalculadora = calc.subtrair(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora); 
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int num1, int num2, int resultado)
        {
            int resultadoCalculadora = calc.multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora); 
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int num1, int num2, int resultado)
        {
            int resultadoCalculadora = calc.dividir(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora); 
        }

        [Fact]
        public void TesteDivisaoPorZero()
        {
            Assert.Throws<DivideByZeroException>(() => calc.dividir(3, 0));
        }

        [Fact]
        public void TesteHistorico()
        {
            calc.somar(1, 2);
            calc.somar(4, 5);
            calc.somar(3, 7);
            calc.somar(4, 1);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
