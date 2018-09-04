using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
// To begin with we do [Test] and then [TestCase]
// TearDown is not used in this project.
// Remember: Arrange, Act, Assert!

namespace Calculator.Test.Unit
{
    [TestFixture] // tells NUnit that this is a test and !Class
    [Author("Ramtin Asef, au442965")]
    public class TestCalculator
    {
        private Calculator _uut;

        [SetUp]
        public void Setup()
        {
            // Arrange
           _uut = new Calculator(); // This way, we don't have to init _uut each time => saves codelines => saves time!
        }

        [Test] // tells NUnit that this is !Function/method
        public void Add_Add2and4_Returns6()
        {
            //Arrange - next line commented out, bc of [SetUP]
            // var _uut = new Calculator(); // Unit Under Test - det objekt jeg gerne vil test på

            //Act + Assert
            Assert.That(_uut.Add(2,4), Is.EqualTo(6));
        }

        [Test]
        public void Add_AddMinus2Plus4_Returns2()
        {
            // var _uut = new Calculator();

            Assert.That(_uut.Add(-2, 4), Is.EqualTo(2));
        }

        [Test]
        public void Substract_Substract5and5_Returns0()
        {
            // var _uut = new Calculator();

            Assert.That(_uut.Subtract(5, 5), Is.EqualTo(0));
        }

        [Test]
        public void Substract_Substract5and7_ReturnsMinus2()
        {
            // var _uut = new Calculator();

            Assert.That(_uut.Subtract(5, 7), Is.EqualTo(-2));
        }

        [Test]
        public void Mulitply_Multiply3and4_Returns12()
        {
            // var _uut = new Calculator();

            Assert.That(_uut.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Multiply_Multiply0and2_Returns0()
        {
            // var _uut = new Calculator();

            Assert.That(_uut.Multiply(0, 2), Is.EqualTo(0));
        }

        [Test]
        public void Power_Power2and3_Returns8()
        {
            //Power is in this example 2*2*2=8
            // var _uut = new Calculator();

            Assert.That(_uut.Power(2, 3), Is.EqualTo(8));
        }
        
        // We've now tried [Test] and for the above, why can conclude, that it is a very slow method.. 
        // Here we try  the [TestCase] showing that it is by far much faster/easier
        // ... when same method is tried with different values!
        [TestCase(2,3,6)]
        [TestCase(-2, 3.5, -7)]
        [TestCase(2, 2, 4)]

        public void Multiply_MultiplyWithTestCase(double aNy, double bNy, double expectedResult)
        {
           // var _uut = new Calculator();
            var total = _uut.Multiply(aNy, bNy);
            Assert.AreEqual(total, expectedResult);
        }

        /*
         * [SetUP] and [TearDown] - useful in e.g. inheritance.
         * Dont use more than 1 SetUP/TearDown pr. class if possible (=> order is unknown).
         * SetUP runs before tests and TearDown runs after.
         * TearDown runs only if SetUP is ok.
        */
    }
}
