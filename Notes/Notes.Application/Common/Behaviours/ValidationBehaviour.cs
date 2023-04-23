using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Notes.Application.Common.Behaviours
{
    public class ValidationBehaviour<Trequest, TResponse> :
        IPipelineBehavior<Trequest, TResponse> where Trequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<Trequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(Trequest request,
            RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<Trequest>(request);
            var failures = _validators.Select(v => v.Validate(context)).
            SelectMany(result => result.Errors).
            Where(failure => failure != null).ToList();
            if(failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
