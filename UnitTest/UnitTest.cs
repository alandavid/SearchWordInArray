using Business;
using Business.Interfaces;
using Business.Managers;
using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        public char[,] matriz = MatrizHelper.matriz;

        [ClassInitialize]
        public static void InitClass(TestContext ctx)
        {

        }
        [TestMethod]
        public void PruebaMetodoSearchSuperior60Porciento()
        {
            IManagerSearch managerSearch = new ManagerSearch();
            var resp1 = managerSearch.findWord(matriz, "JAVA");
            Assert.IsNotNull(resp1);
            Assert.AreEqual("[2,2,][3,3,][4,4,][5,5,]", resp1);
            var resp2 = managerSearch.findWord(matriz, "VIACOM");
            Assert.IsNotNull(resp2);
            Assert.AreEqual("[1,3,][2,3,][3,3,][4,3,][5,3,][6,3,]", resp2);
            var resp3 = managerSearch.findWord(matriz, "TELEFE");
            Assert.IsNotNull(resp3);
            Assert.AreEqual("[7,1,][7,2,][7,3,][7,4,][7,5,][7,6,]", resp3);

        
        }



    }
}
