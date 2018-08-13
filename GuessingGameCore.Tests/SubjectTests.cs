using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame.Core.Tests {
    [TestClass]
    public class SubjectTests {
        [TestMethod]
        public void Subject_WithName_CreatesWithNameAndEmptyCharacteristics() {
            var subject = new Subject("Chell");

            Assert.AreEqual(subject.Name, "Chell");
            Assert.IsNotNull(subject.Traits);
            Assert.AreEqual(subject.Traits.Count, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Subject_WithoutName_Fails() {
            var _ = new Subject(null);
        }

        [TestMethod]
        public void ToString_DisplaysName() {
            var subject = new Subject("Chell");

            Assert.AreEqual(subject.ToString(), "Chell");
        }
    }
}
