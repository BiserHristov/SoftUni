using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class DataConstants
    {
        //User
        public const int IdMaxLength = 40;
        public const int UsernameMaxLength = 20;
        public const int UsernameMinLength = 4;
        public const int UserMinPassword = 5;
        public const int UserMaxPassword = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        //Car
        public const int CarMinLength = 5;
        public const int CarMaxLength = 20;
        public const int CarMaxPlateNumberLength = 8;

        //public const int RepositoryMinName = 3;
        //public const int RepositoryMaxName = 10;
        //public const string RepositoryPublicType = "Public";
        //public const string RepositoryPrivateType = "Private";

        //public const int CommitMinDescription = 5;
    }
}
