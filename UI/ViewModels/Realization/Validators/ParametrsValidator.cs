using FluentValidation;
using System;

namespace UI.ViewModels.Realization.Validators
{
    public class ParametrsValidator : AbstractValidator<ParametsViewModel>
    {
        public ParametrsValidator()
        {
            _ = RuleFor(c => c.Strips).NotEmpty().WithMessage("Strip not added");
            _ = RuleFor(x => x.SelectedKnife).NotNull();
            _ = RuleFor(x => x.RollWidth).ExclusiveBetween(0, 2000).WithMessage("Roll width range from 0 to 2000");
            _ = RuleFor(x => x.CuttingMachine).NotEqual(0).WithMessage("No cutting machine selected");
            _ = RuleFor(x => x.Thickness).Must(ValidThickness).WithMessage("material thickness range from 0.1 to 6 millimeters");
        }
        private bool ValidThickness(double value)
        {
            return ((value - Math.Round(value, 3)) == 0) && value >= 0.1d && value < 6;
        }
    }
}
