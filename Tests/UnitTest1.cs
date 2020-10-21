using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banka;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        Sporici TestS = new Sporici("testS", 0);
        Uverovy TestU = new Uverovy("tetsU", 0, 31);
        Studentsky TestStudent = new Studentsky("testStudent", 0);
        [TestMethod]
        public void TestMethod1()
        {
            // Zjistit zda funguje odečítání a přičítaní peněz - Spořící
            //Arrange
            double sazba = 0.02;
            double O = -100;
            double testZustatek = 0;
            TestS.Zustatek = 0;
            //Act
            testZustatek = O/sazba;
            O = 0 + testZustatek;
            TestS.Vybrat("100");
            TestS.Mesic();
            //Assert
            Assert.AreNotSame(O,TestS.Zustatek);
        }
        [TestMethod]
        public void TestMethod5()
        {
            // Zjistit zda funguje odečítání a přičítaní peněz - Uvěrový
            //Arrange
            double sazba = 0.2;
            double O = 1;
            double testZustatek = 0;
            TestU.Zustatek = 0;
            //Act
            TestU.Pridat("101");
            TestU.Mesic();
            testZustatek = O / sazba;
            O = testZustatek + O;
            //Assert
            Assert.AreNotSame(O, TestU.Zustatek);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // Když je na kreditním nula úrok je take nula aka nezvetší se dluh
            //Arrange
            //Act
            //Assert
        }
        public void TestMethod3()
        {
            // Správné nastavemí času 
            //Arrange
            //Act
            //Assert
        }
        public void TestMethod4()
        {
            // Limity účtu a jejich účtování
            //Arrange
            //Act
            //Assert
        }
    }
}
