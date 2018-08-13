using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame.Core.Tests {
    [TestClass]
    public class TraitTests {
        [TestMethod]
        public void Trait_WithName_CreatesWithDescription() {
            var trait = new Trait("can fly");

            Assert.AreEqual(trait.Description, "can fly");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Trait_WithoutName_Fails() {
            var _ = new Trait(null);
        }

        [TestMethod]
        public void ToString_DisplaysDescription() {
            var trait = new Trait("can fly");

            Assert.AreEqual(trait.ToString(), "can fly");
        }

        [TestMethod]
        public void ValueEquality() {
            var a = new Trait("can fly");
            var b = new Trait("can fly");
            var c = new Trait("can swim");

            Assert.AreEqual(a, a);
            Assert.AreEqual(a, b);
            Assert.AreNotEqual(a, c);
            Assert.AreNotEqual(b, c);
        }
    }
}
