using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Issues
{
    public class IssueOutputModel
    {
        public string Id { get; init; }
        public string Description { get; init; }
        public bool IsFixed { get; init; }


    }
}
