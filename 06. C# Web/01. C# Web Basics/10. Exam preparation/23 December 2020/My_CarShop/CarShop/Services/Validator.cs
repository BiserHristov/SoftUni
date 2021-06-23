namespace CarShop.Services
{
    using CarShop.Models.Cars;
    using CarShop.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateAddCarr(CarInputAddModel model)
        {
            var errors = new List<string>();

            if (model.Model == null ||
                model.Model.Length < CarMinLength ||
                model.Model.Length > CarMaxLength)
            {
                errors.Add($"Model '{model.Model}' is not valid. It must be between {CarMinLength} and {CarMaxLength} characters long.");
            }

            if (model.Image == null)
            {
                errors.Add("Image can not be null");
            }

            if (model.PlateNumber == null ||
                !Regex.IsMatch(model.PlateNumber, CarPlateRegexExpression))
            {
                errors.Add($"Plate  '{model.PlateNumber}' is not a valid plate number.");
            }

            if (model.Year < 1000 ||
                model.Year > DateTime.Now.Year)
            {
                errors.Add("Year is not valid");
            }

            return errors;

        }

        public ICollection<string> ValidateUser(UserInputRegisterModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > UserMaxPassword)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {UserMaxPassword} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if (model.UserType != "Client" && model.UserType != "Mechanic")
            {
                errors.Add($"Client type is not valid.");
            }

            return errors;
        }

        //public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        //{
        //    var errors = new List<string>();

        //    if (model.Name.Length < RepositoryMinName || model.Name.Length > RepositoryMaxName)
        //    {
        //        errors.Add($"Repository '{model.Name}' is not valid. It must be between {RepositoryMinName} and {RepositoryMinName} characters long.");
        //    }

        //    if (model.RepositoryType != RepositoryPublicType && model.RepositoryType != RepositoryPrivateType)
        //    {
        //        errors.Add($"Repository type can be either '{RepositoryPublicType}' or '{RepositoryPrivateType}'.");
        //    }

        //    return errors;
        //}
    }
}
