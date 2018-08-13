using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.Core.Gameplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame.Core.Tests {
    [TestClass]
    public class GameTests {
        [TestMethod]
        public void Game_WithParameters_StoresInContext() {
            var solver = new SolverWorld();
            var ui = new TestUserInterface();
            var game = new Game(solver, ui);

            Assert.Equals(game.Solver, solver);
            Assert.Equals(game.Ui, ui);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Game_WithoutSolver_Fails() {
            var ui = new TestUserInterface();
            var _ = new Game(null, ui);
		}

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Game_WithoutUi_Fails() {
            var solver = new SolverWorld();
            var _ = new Game(solver, null);
        }
	}
}
