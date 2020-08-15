using System;
using System.Collections.Generic;
using System.Text;
using HAD.Contracts;

namespace HAD.Entities.Items
{
    public class RecipeItem : CommonItem
    {
        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus) : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
            this.RequiredItems = new List<CommonItem>();
        }

        public ICollection<CommonItem> RequiredItems { get; }
    }
}
