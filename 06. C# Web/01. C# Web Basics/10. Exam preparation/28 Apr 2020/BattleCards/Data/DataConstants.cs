namespace BattleCards.Data
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
   
        //Card
        public const int CardNameMinLength = 5;
        public const int CardNameMaxLength = 15;
        public const int CardDescripttionMaxLength = 200;
        public const int CardAttackHealthMinValue = 0;


        //public const int CarPlateNumberMaxLength = 8;
        //public const string CarPlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        //public const int CarYearMinValue = 1900;
        //public const int CarYearMaxValue = 2100;

        //public const int IssueMinDescription = 5;
    }
}
