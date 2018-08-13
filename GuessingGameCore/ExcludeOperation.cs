using System.Collections.Generic;
using System.Linq;

namespace GuessingGame.Core {
    public class ExcludeOperation : IQueryOperation {
        public Trait Removal { get; }

        public ExcludeOperation(Trait removal) {
            Removal = removal;
        }

        public IEnumerable<Subject> Apply(IEnumerable<Subject> subjects) => subjects
            .Where(subject => !subject.Traits.Contains(Removal));
    }
}
