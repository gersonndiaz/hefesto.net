using Hefesto.Patente;
using NUnit.Framework;

namespace Hefesto.Tests
{
    [TestFixture]
    public class PatenteTests
    {
        [TestCase("GBSZ41")]
        [TestCase("GCSZ32")]
        [TestCase("AA·10·00")]
        [TestCase("BB·BB·10")]
        [TestCase("PR·206")]
        [TestCase("RP·2001")]
        [TestCase("Z·3750")]
        [TestCase("BB·LB·30")]
        [TestCase("CD·0510")]
        [TestCase("BB·WB·40")]
        [TestCase("BG·BB·70")]
        [TestCase("VPU·184")]
        [TestCase("BC·BB·60")]
        [TestCase("JA·10·00")]
        [TestCase("WS·19·00")]
        public void ValidarPatente_VariosFormatos_ValidaCorrectamente(string patente)
        {
            // Arrange
            bool expectedResult = true;

            // Act
            bool actualResult = PatenteChile.Validar(patente);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("AAA·10·00")]
        [TestCase("BB·BBB·10")]
        [TestCase("PR·2066")]
        [TestCase("RP·200")]
        [TestCase("Z·37500")]
        [TestCase("BB·LB·300")]
        [TestCase("CD·05101")]
        [TestCase("BB·WB·400")]
        [TestCase("BG·BBB·70")]
        [TestCase("VPU·1844")]
        [TestCase("BC·BB·600")]
        [TestCase("JA·100·00")]
        [TestCase("WS·190·00")]
        public void ValidarPatente_FormatosInvalidos_NoValidaCorrectamente(string patente)
        {
            // Arrange
            bool expectedResult = false;

            // Act
            bool actualResult = PatenteChile.Validar(patente);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
