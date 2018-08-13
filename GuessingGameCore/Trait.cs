using System;
using System.Xml.Serialization;

namespace GuessingGame.Core {
	[Serializable]
	public struct Trait {
		[XmlAttribute]
		public string Description { get; set; }

		public Trait(string description) {
			Description = description ?? throw new ArgumentNullException(nameof(description));
		}

		public override string ToString() => Description;
	}
}