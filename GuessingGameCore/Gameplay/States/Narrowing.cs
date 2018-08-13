using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay.States {
	internal class Narrowing : IGameState {
		public async Task<IGameState> Run(Game game) {
			var query = new Query(game.Solver.Subjects);
			var askedTraits = new List<Trait>();

			while (query.Results.Count > 1) {
				var trait = PickUnusedTrait(query, askedTraits);

				if (trait == null) {
					break;
				}

				if (await game.Ui.Confirmation($"Does the animal you thought about {trait}?")) {
					query = query.Bind(new ConstrainOperation(trait.Value));
				} else {
					query = query.Bind(new ExcludeOperation(trait.Value));
				}
			}

			return new Guessing(query);
		}

		private Trait? PickUnusedTrait(Query query, ICollection<Trait> askedTraits) {
			var unused = query.Results
				.SelectMany(subject => subject.Traits)
				.Except(askedTraits)
				.ToArray();

			if (unused.Length == 0) {
				return null;
			}

			var trait = unused[0];
			askedTraits.Add(trait);
			return trait;
		}
	}
}