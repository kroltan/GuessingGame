using System;
using System.Collections.Generic;

namespace GuessingGame.Core {
    public class Subject {
        public string Name { get; }
        public HashSet<Trait> Traits { get; }

        public Subject(string name) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Traits = new HashSet<Trait>();
        }

        public override string ToString() => Name;
    }
}
