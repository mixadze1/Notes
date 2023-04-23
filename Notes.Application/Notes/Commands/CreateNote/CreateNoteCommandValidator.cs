﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.Title).
                NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
            createNoteCommand.userId).NotEqual(Guid.Empty);
        }
      
    }
}
