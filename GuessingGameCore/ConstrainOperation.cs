using System.Collections.Generic;
using System.Linq;

namespace GuessingGame.Core {
    public class ConstrainOperation : IQueryOperation {
        public Trait RequiredTrait { get; }

        public ConstrainOperation(Trait requiredTrait) {
            RequiredTrait = requiredTrait;
        }

        public IEnumerable<Subject> Apply(IEnumerable<Subject> subjects) => subjects
            .Where(subject => subject.Traits.Contains(RequiredTrait));
    }
}
