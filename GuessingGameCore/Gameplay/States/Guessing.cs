using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay.States {
	internal class Guessing : IGameState {
		private readonly Query _query;

		public Guessing(Query query) {
			_query = query;
		}

		public async Task<IGameState> Run(Game game) {
			foreach (var subject in _query.Results) {
				if (await game.Ui.Confirmation($"Is the animal you thought about a {subject}?")) {
					return new Finished();
				}
			}

			return new Cataloguing(_query);
		}
	}
}