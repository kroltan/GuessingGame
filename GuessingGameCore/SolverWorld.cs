using System;
using System.Collections.Generic;

namespace GuessingGame.Core {
    [Serializable]
    public class SolverWorld {
        public HashSet<Subject> Subjects { get; private set; } = new HashSet<Subject>();

        public void Insert(Subject subject) {
            if (subject == null) {
                throw new ArgumentNullException(nameof(subject));
            }

            Subjects.Add(subject);
        }
    }
}
