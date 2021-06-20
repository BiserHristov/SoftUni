

using Git.Models.Commits;
using Git.Models.Repositories;
using Git.Models.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateCommitCreation(CommitCreateModel model)
        {
            var errors = new List<string>();
            if (model.Description.Length<5)
            {
                errors.Add("Commmit lenth is too short");
            }

            return errors;
        }

        public ICollection<string> ValidateRepositoryCreation(RepositoryCreateModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name) ||
                model.Name.Length < 3 ||
                model.Name.Length > 10)
            {
                errors.Add("Name is not valid!");
            }

            if (model.RepositoryType != "Private" &&
                model.RepositoryType != "Public")
            {
                errors.Add("RepositoryType is not valid!");
            }

            return errors;
        }

        public ICollection<string> ValidateUserRegistration(UserRegisterModel model)
        {
            var errors = new List<string>();
            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add("Username is not valid!");
            }

            if (!Regex.IsMatch(
                    model.Email,
                    @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add("Email is not valid!");

            }


            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add("Password is not valid!");

            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and confirm-password do not match!");

            }


            return errors;

        }


    }
}
