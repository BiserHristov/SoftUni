using CarShop.Models.Cars;
using CarShop.Models.Users;
using System.Collections.Generic;

namespace CarShop.Services
{
    
    public interface IValidator
    {
        ICollection<string> ValidateUser(UserInputRegisterModel model);

       ICollection<string> ValidateAddCarr(CarInputAddModel model);
    }
}
