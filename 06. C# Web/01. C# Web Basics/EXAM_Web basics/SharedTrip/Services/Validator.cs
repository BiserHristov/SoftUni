namespace SharedTrip.Services
{
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(TripAddFormModel trip)
        {
            var errors = new List<string>();

            if (trip.StartPoint == null)
            {
                errors.Add("Start point is required and can not be null!");
            }

            if (trip.EndPoint == null)
            {
                errors.Add("End point is required and can not be null!");
            }


            if (trip.DepartureTime == null)
            {
                errors.Add("Departure time is required and can not be null!");
            }

            DateTime result;
            if (!DateTime.TryParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                errors.Add("Departure time is not in the correct time format!");
            }


            if (trip.Seats < TripSeatsMinValue || trip.Seats > TripSeatsMaxValue)
            {
                errors.Add($"Seats count '{trip.Seats}' is not valid. It must be between {TripSeatsMinValue} and {TripSeatsMaxValue}.");
            }

            if (trip.Description == null || trip.Description.Length > TripDescriptionMaxLength)
            {
                errors.Add($"Description '{trip.Description}' is not valid. It must be less than {TripDescriptionMaxLength} characters long and can not be null.");
            }

            if (trip.ImagePath == null || !Uri.IsWellFormedUriString(trip.ImagePath, UriKind.Absolute))
            {
                errors.Add($"Image '{trip.ImagePath }' is not valid. It must be a valid URL.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > PasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.ConfirmPassword != null && user.ConfirmPassword.Any(x => x == ' '))
            {
                errors.Add($"The provided confirm password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }



            return errors;
        }


    }
}
