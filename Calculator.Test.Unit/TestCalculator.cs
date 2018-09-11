using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using NUnit.Framework.Internal;

// To begin with we do [Test] and then [TestCase]
// TearDown is not used in this project.
// Remember: Arrange, Act, Assert!

namespace Calculator.Test.Unit
{
    [TestFixture] // Tag to tell NUnit that this is a test and not a class.
    [Author("STWgruppe20")]
    public class TestCalculator
    {
        private Calculator _uut;

        [SetUp]
        public void Setup() {
            // Arrange
           _uut = new Calculator(); // This way, we don't have to initiate a new instance each time => saves codelines => saves time!
        }

        [Test] // tells NUnit that this is !Function/method

        //Test af addition
        public void Add_Add2and4_Returns6() {
            Assert.That(_uut.Add(2,4), Is.EqualTo(6));
        }

        [Test]
        public void Add_AddMinus2Plus4_Returns2() {
            Assert.That(_uut.Add(-2, 4), Is.EqualTo(2));
        }

        [Test]
        public void Substract_Substract5and5_Returns0() {
            Assert.That(_uut.Subtract(5, 5), Is.EqualTo(0));
        }

        [Test]
        public void Substract_Substract5and7_ReturnsMinus2() {
            Assert.That(_uut.Subtract(5, 7), Is.EqualTo(-2));
        }

        [Test]
        public void Substract_SubstractNegative5and7_ReturnsNegative12() {
            Assert.That(_uut.Subtract(-5, 7), Is.EqualTo(-12));
        }

        [Test]
        public void Mulitply_Multiply3and4_Returns12() {
            Assert.That(_uut.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Multiply_Multiply0and2_Returns0() {
            Assert.That(_uut.Multiply(0, 2), Is.EqualTo(0));
        }

        /*Test af Eksponentiel Funktion*/

        [Test]
        public void Power_Power2and3_Returns8() {
            Assert.That(_uut.Power(2, 3), Is.EqualTo(8));
        }

        [Test]
        public void Power_PowerNegative2and3_Returns8() {
            Assert.That(_uut.Power(-2, 3), Is.EqualTo(-8));
        }

        [Test]
        public void Power_Power2dot13and3_Returns9dot52818() {
          Assert.That(_uut.Power(2.5, 3), Is.EqualTo(15.625));
        }

        [Test]
        public void Power_PowerNegative2dot13And3_ReturnsNegative15dot625() {
            Assert.That(_uut.Power(-2.5, 3), Is.EqualTo(-15.625));
        }

        [Test]
        public void Divide_Divide10and5Return2() {
            Assert.That(_uut.Divide(10,5),Is.EqualTo(2));
        }

        [Test]
        public void Divide_Dividenegative10and5Return2() {
            Assert.That(_uut.Divide(-10, 5), Is.EqualTo(-2));
        }

        [Test]
        public void Divide_Divide0and5Return2() {
            Assert.That(_uut.Divide(0, 5), Is.EqualTo(0));
        }

        /*
        [Test]
        public void Divide_Divide5and0ReturnError()
        {
            Assert.That(_uut.Divide(5, 0), Is.EqualTo(-1)); 
        }
        
        The test suite wont accept division by zero, not sure if the program is crashing or internal 
        error handling is preventing the test suite from being run
        - Thomas 

        */
        /* Above we've tried using the tag [Test]. We can conclude that the method of using [Test] is rather slow and inefficient to write out. 
           Therefore we continue with the tag [TestCase]. This tag is a lot faster to work with, if you're working with the same method a few times and only need to change the values.
        */

        [TestCase(2,3,6)]
        [TestCase(-2, 3.5, -7)]
        [TestCase(2, 2, 4)]
        [TestCase(2, 0, 0)]
        public void Multiply_MultiplyWithTestCase(double aNy, double bNy, double expectedResult) {
           var total = _uut.Multiply(aNy, bNy);
            Assert.AreEqual(total, expectedResult);
        }

        [Test]
        public void Accumulator_ReturnMultiply() {
            _uut.Multiply(2, 2); //Accumulator = 4
            _uut.Add(_uut.Accumulator, 2); // Accumulator = 6
            //gentag test for alle funktioner

            double testAccul = _uut.Accumulator;
            Assert.AreEqual(testAccul, 6);
        }

        [Test]
        public void Accumulator_ReturnResultFromAdd() {
            _uut.Multiply(2, 2);    //Accumulator = 4
            _uut.Divide(10, 2);     //Accumulator = 5
            _uut.Divide(8,2);       // Accumulator = 4

            double testAccul = _uut.Accumulator;
            Assert.AreEqual(testAccul, 4);
        }

        [Test]
        public void Accumulator_ReturnResultFromDivide() {
            _uut.Multiply(2, 2);    //Accumulator = 4
            _uut.Divide(10, 2);     //Accumulator = 5
            _uut.Add(8, 8);         // Accumulator = 16
            _uut.Multiply(2, 2);    //Accumulator = 4
            _uut.Divide(10, 2);     //Accumulator = 5
            _uut.Add(8, 8);         // Accumulator = 16
            _uut.Divide(10, 2);     //Accumulator = 5

            double testAccul = _uut.Accumulator;
            Assert.AreEqual(testAccul, 5);
        }

        [Test]
        public void Accumulator_ReturnResultFromMultiply() {
            _uut.Multiply(2, 2);    //Accumulator = 4
            _uut.Divide(10, 2);     //Accumulator = 5
            _uut.Add(8, 8);         // Accumulator = 16
            _uut.Multiply(2, 2);    //Accumulator = 4
            _uut.Divide(10, 2);     //Accumulator = 5
            _uut.Add(8, 8);         // Accumulator = 16
            _uut.Multiply(10, 2);     //Accumulator = 20

            double testAccul = _uut.Accumulator;
            Assert.AreEqual(testAccul, 20);
        }

        //A simple Test that will attempt to do different arithmetic calculations with the use of overloads.
        [Test]
        public void AccumlatorOverloadTesting() {
            //addition
            _uut.Add(2, 2); //accumalator = 4
            Assert.AreEqual(_uut.Accumulator, 4);
            _uut.Add(2); // accumulator = 6 -> Overload part
            Assert.AreEqual(_uut.Accumulator, 6);
            _uut.Add(1); //Adding multiple 1's to see if the accumulator is actually being updated when used through overload multiple times in a row.
            _uut.Add(1);
            _uut.Add(1);
            _uut.Add(1);
            _uut.Add(1);
            Assert.AreEqual(_uut.Accumulator, 11);

            //division
            _uut.Divide(10, 2);
            Assert.AreEqual(_uut.Accumulator, 5);
            _uut.Divide(0.5);
            Assert.AreEqual(_uut.Accumulator, 10);

            //subtraction
            _uut.Subtract(10, 5);
            Assert.AreEqual(_uut.Accumulator, 5);
            _uut.Subtract(4, 5);
            Assert.AreEqual(_uut.Accumulator, -1);

            //multiplication
            _uut.Multiply(0.5, 7);
            Assert.AreEqual(_uut.Accumulator, 3.5);
            _uut.Multiply(3);
            Assert.AreEqual(_uut.Accumulator, 10.5);

            //Power
            _uut.Power(10, 2); // 100
            Assert.AreEqual(_uut.Accumulator, 100);
            _uut.Power(2);
            Assert.AreEqual(_uut.Accumulator, 10000);
        }

        [Test]
        public void Clear_ClearAccessorAfterItHoldsAnInteger(){
            _uut.Add(8, 8);         // Accumulator = 16
            _uut.Multiply(10, 2);     //Accumulator = 20
            _uut.Clear();

            double testAccul = _uut.Accumulator;
            Assert.AreEqual(testAccul, 0);
        }

        [Test]
        public void Clear_ClearAccessorAfterItWasClearedAndGivenAValueAgain(){
            _uut.Add(8, 8);         // Accumulator = 16
            _uut.Multiply(10, 2);   //Accumulator = 20
            _uut.Clear();           //Accumulator = 0;
            _uut.Subtract(10, 3);   //Accumulator = 7;
            _uut.Clear();           //Accumulator = 0;

            double testAccul = _uut.Accumulator;
            Assert.AreEqual(testAccul, 0);
        }

        /*
         * [SetUP] and [TearDown] - useful in e.g. inheritance.
         * Dont use more than 1 SetUP/TearDown pr. class if possible (=> order is unknown).
         * SetUP runs before tests and TearDown runs after.
         * TearDown runs only if SetUP is ok.
        */
    }
}
