using System;
using GuessingGame.Core.Gameplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame.Core.Tests {
    [TestClass]
    public class GameTests {
        [TestMethod]
        public void Game_WithParameters_StoresInContext() {
            var solver = new SolverWorld();
            var ui = new DummyUserInterface();
            var game = new Game(solver, ui);

            Assert.Equals(game.Solver, solver);
            Assert.Equals(game.Ui, ui);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Game_WithoutSolver_Fails() {
            var ui = new DummyUserInterface();
            var _ = new Game(null, ui);
		}

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Game_WithoutUi_Fails() {
            var solver = new SolverWorld();
            var _ = new Game(solver, null);
        }

        // TODO: Figure out how to test state machine.
	}
}
