using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculos.Test
    {
    public class CalculoUnitTest
        {
        //Princípio AAA: Act, Arrange e Assert => Agir, Organizar e Provar
        [Fact]
        public void SomarDoisNumeros()
            {
            //Organizar
            var n1 = 3.3;
            var n2 = 2.2;
            var expectedValue = 5.6;

            //Agir
            var plus = Calculo.Somar(n1, n2);

            //Provar
            Assert.Equal(expectedValue, plus);
            }

        [Fact]
        public void SubtrairDoisNumeros()
            {
            var n1 = 3;
            var n2 = 2;
            var expectedValue = 1;

            var subtract = Calculo.Subtrair(n1, n2);

            Assert.Equal(expectedValue, subtract);
            }
        [Fact]
        public void DividirDoisNumeros()
            {
            var n1 = 6;
            var n2 = 2;
            var expectedValue = 4;

            var divide = Calculo.Dividir(n1, n2);

            Assert.Equal(expectedValue, divide);
            }
        [Fact]
        public void MultiplicarDoisNumeros()
            {
            var n1 = 3;
            var n2 = 2;
            var expectedValue = 6;

            var multiplicate = Calculo.Multiplicar(n1, n2);

            Assert.Equal(expectedValue, multiplicate);
            }
        [Fact]
        public void ModularDoisNumeros()
            {
            var n1 = 10;
            var n2 = 4;
            var expectedValue = 3;

            var module = Calculo.Modular(n1, n2);

            Assert.Equal(expectedValue, module);
            }
        }
    }
