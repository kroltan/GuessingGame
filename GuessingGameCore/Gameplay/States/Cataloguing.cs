using System.Linq;
using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay.States {
	internal class Cataloguing : IGameState {
		private readonly Query _query;

		public Cataloguing(Query query) {
			_query = query;
		}

		public async Task<IGameState> Run(Game game) {
			var name = await game.Ui.Input("What was the animal that you thought about?");

			var subject = new Subject(name.Trim());
			AddKnownTraits(subject);

			var description = await game.Ui.Input(
				$"A {subject} _____ but a {_query.Results.LastOrDefault()} does not"
				+ " (Fill it with an animal trait, like \"lives in water\")"
			);

			subject.Traits.Add(new Trait(description.Trim()));

			game.Solver.Insert(subject);

			return null;
		}

		private void AddKnownTraits(Subject subject) {
			var queriedTraits = _query.Operations
				.OfType<ConstrainOperation>()
				.Select(operation => operation.RequiredTrait);

			foreach (var trait in queriedTraits) {
				subject.Traits.Add(trait);
			}
		}
	}
}