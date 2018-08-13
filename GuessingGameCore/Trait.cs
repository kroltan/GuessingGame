using System;

namespace GuessingGame.Core {
	[Serializable]
	public struct Trait {
		public string Description { get; }

		public Trait(string description) {
			Description = description ?? throw new ArgumentNullException(nameof(description));
		}

		public override string ToString() => Description;
	}
}