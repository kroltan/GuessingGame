using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessingGame.Core;

namespace GuessingGame.Core.Tests {
    [TestClass]
    public class SolverWorldTests {
        [TestMethod]
        public void Solver_InitiallyEmpty() {
            Assert.AreEqual(new SolverWorld().Subjects.Count(), 0, "Subjects.Count() == 0");
        }

        [TestMethod]
        public void Insert_WithSubject_AddsSubjectToWorld() {
            var solver = new SolverWorld();
            solver.Insert(new Subject("Chell"));

            Assert.AreEqual(solver.Subjects.Count(), 1, "Subjects.Count() == 1");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Insert_WithoutSubject_Fails() {
            var solver = new SolverWorld();
            solver.Insert(null);
        }
    }
}
