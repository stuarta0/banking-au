using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation
{
    public class CompositeValidator<T> : IValidator<T>
    {
        protected IList<IValidator<T>> _validators;
        protected CompositeValidator()
        { }
        public CompositeValidator(IList<IValidator<T>> validators)
        {
            _validators = validators;
        }

        public virtual void Clean(T item)
        {
            foreach (var v in _validators)
                v.Clean(item);
        }

        public virtual IEnumerable<IError> Validate(T item)
        {
            foreach (var v in _validators)
                foreach (var e in v.Validate(item))
                    yield return e;
        }
    }
}
