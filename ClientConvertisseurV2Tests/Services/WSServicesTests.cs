using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientConvertisseurV2.ViewModels;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServicesTests
    {
        [TestMethod()]
        public void WSServicesTest()
        {
            WSServices service = new WSServices("https://localhost:7058/api/");
            Assert.IsNotNull(service);
        }
        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            //Arrange
            WSServices service = new WSServices("https://localhost:7058/api/devises");
            var result = service.GetDevisesAsync("devises").Result;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Devise>));
            Assert.AreEqual(3, result.Count());
        }
    }
}