using NUnit.Framework;
using PetShop.Data.Models;

namespace PetShop.Tests
{
    public class Tests
    {
        public Animal MyProperty { get; set; }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}