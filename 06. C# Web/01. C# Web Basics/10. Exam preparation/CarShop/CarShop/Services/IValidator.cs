

using CarShop.Models.Users;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUserRegistration(UserRegisterModel model);

        //ICollection<string> ValidateRepositoryCreation(RepositoryCreateModel model);
        //ICollection<string> ValidateCommitCreation(CommitCreateModel model);

    }
}
