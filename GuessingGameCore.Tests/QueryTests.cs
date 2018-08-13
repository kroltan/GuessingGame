using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame.Core.Tests {
    [TestClass]
    public class QueryTests {
        [TestMethod]
        public void Query_WithSolver_ContainsFullWorld() {
            var solver = new SolverWorld();
            solver.Insert(new Subject("Chell"));
            solver.Insert(new Subject("P-body"));
            solver.Insert(new Subject("Atlas"));

            var query = new Query(solver.Subjects);

            Assert.AreEqual(
                query.Results.Union(solver.Subjects).Count(),
                3,
                "Subjects and ResultSet contain the same items"
            );
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Query_WithoutSolver_Fails() {
            var _ = new Query(null);
        }

        [TestMethod]
        public void Including_WithCharacteristic_NarrowsResultSet() {
            var (solver, flying, _) = WorldWithAFlyingAnimal();

            var narrowed = new Query(solver.Subjects)
                .Bind(new ConstrainOperation(new Trait("flies")));
            
            CollectionAssert.AreEquivalent(
                new[] {flying},
                narrowed.Results.ToArray()
            );
        }

        [TestMethod]
        public void Excluding_WithCharacteristic_NarrowsResultSet() {
            var (solver, _, rest) = WorldWithAFlyingAnimal();

            var narrowed = new Query(solver.Subjects)
                .Bind(new ExcludeOperation(new Trait("flies")));

            CollectionAssert.AreEquivalent(
                rest,
                narrowed.Results.ToArray()
            );
        }

        private (
            SolverWorld solver,
            Subject flying,
            Subject[] rest
        ) WorldWithAFlyingAnimal() {
            var solver = new SolverWorld();
            var flying = new Subject("African Swallow");
            flying.Traits.Add(new Trait("flies"));
            var b = new Subject("Penguin");
            var c = new Subject("Chicken");

            solver.Insert(flying);
            solver.Insert(b);
            solver.Insert(c);

            return (solver, flying, new[] {b, c});
        }
    }
}
