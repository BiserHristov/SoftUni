using BattleCards.Models.Cards;
using BattleCards.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateCard(CreateCardFormModel model);

        //ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
