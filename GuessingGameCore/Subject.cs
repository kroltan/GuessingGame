using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GuessingGame.Core {
    [Serializable]
    public class Subject {
        [XmlAttribute]
        public string Name { get; set; }
        public HashSet<Trait> Traits { get; }

        private Subject() {
            Traits = new HashSet<Trait>();
        }

        public Subject(string name) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Traits = new HashSet<Trait>();
        }

        public override string ToString() => Name;
    }
}
