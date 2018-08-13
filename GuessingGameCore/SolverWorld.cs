using System;
using System.Collections.Generic;

namespace GuessingGame.Core {
    [Serializable]
    public class SolverWorld {
        private readonly HashSet<Subject> _subjects = new HashSet<Subject>();

        public IReadOnlyCollection<Subject> Subjects => _subjects;

        public void Insert(Subject subject) {
            if (subject == null) {
                throw new ArgumentNullException(nameof(subject));
            }

            _subjects.Add(subject);
        }
    }
}
