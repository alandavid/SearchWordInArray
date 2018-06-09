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
            var resp2 = managerSearch.findWord(matriz, "VIACOM");
            var resp3 = managerSearch.findWord(matriz, "TELEFE");
            Assert.IsNotNull(resp1);
            Assert.IsNotNull(resp2);
            Assert.IsNotNull(resp3);
        }



    }
}
