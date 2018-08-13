using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay {
	internal class Finished : IGameState {
		public async Task<IGameState> Run(Game game) {
			await game.Ui.Confirmation("I win again!");

			return null;
		}
	}
}