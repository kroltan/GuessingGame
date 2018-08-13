using System.Diagnostics;
using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay.States {
	internal class Starting : IGameState {
        public async Task<IGameState> Run(Game game) {
			Debug.WriteLine("Current population:");
	        foreach (var subject in game.Solver.Subjects) {
		        Debug.WriteLine($"[{subject}]: {string.Join(", ", subject.Traits)}");
	        }

            if (!await game.Ui.Confirmation("Think of an animal...")) {
	            game.Stop();
				return null;
			}

			return new Narrowing();
        }
    }
}
