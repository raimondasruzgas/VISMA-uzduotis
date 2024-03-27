using Microsoft.VisualStudio.TestTools.UnitTesting;
using VISMAtas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISMAtas.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            User user = new User();
            user.Name = "Raimis";
            Assert.AreEqual("Raimis", user.ToString());
        }
    }
}