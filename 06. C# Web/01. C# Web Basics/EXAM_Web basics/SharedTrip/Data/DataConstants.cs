namespace SharedTrip.Data
{
    public class DataConstants
    {
        //User
        public const int IdMaxLength = 40;
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
   

        //Trip
        public const int TripSeatsMinValue = 2;
        public const int TripSeatsMaxValue = 6;
        public const int TripDescriptionMaxLength = 80;
        public const string DepartureTimeFormat = "dd.MM.yyyy HH:mm";


    }
}
