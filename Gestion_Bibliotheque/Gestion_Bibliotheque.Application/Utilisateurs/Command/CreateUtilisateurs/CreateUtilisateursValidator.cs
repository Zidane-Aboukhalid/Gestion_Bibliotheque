using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.CreateUtilisateurs;

public class CreateUtilisateursValidator : AbstractValidator<createUtilisateur>
{
    public CreateUtilisateursValidator()
    {
		RuleFor(v => v.Id)
	        .Cascade(CascadeMode.Stop)
	        .NotEmpty().WithMessage("Id is required.")
	        .NotNull().WithMessage("Id cannot be null.")
	        .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Id must be a valid Guid.");


		RuleFor(v => v.Email)
            .NotEmpty().WithMessage("'Email' is required.")
            .EmailAddress().WithMessage("This is an example of a valid email: example@example.com");

        RuleFor(v => v.Nom)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("'Nom' must not exceed 100 characters.");

        RuleFor(v => v.Prenom)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("'Prenom' must not exceed 100 characters.");

        RuleFor(v => v.Adresse)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(500).WithMessage("'Adresse' must not exceed 500 characters.");

        RuleFor(v => v.JobInTech)
            .NotEmpty().WithMessage("'JobInTech' is required.")
            .Must(v => v is bool).WithMessage("'JobInTech' must be a boolean value.");

        RuleFor(v => v.Ecol)
            .NotEmpty().WithMessage("Ecol is required.")
            .MaximumLength(500).WithMessage("'Ecol' must not exceed 500 characters.");

        RuleFor(v => v.PasswordHash)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(7).WithMessage("Password must have a minimum of 7 characters.")
            .MaximumLength(15).WithMessage("Password must not exceed 15 characters.")
            .Matches(@"[!@#\$%^&*(),.?""\\:{}|<>]").WithMessage("Password must contain at least 2 special characters.");


    }
}