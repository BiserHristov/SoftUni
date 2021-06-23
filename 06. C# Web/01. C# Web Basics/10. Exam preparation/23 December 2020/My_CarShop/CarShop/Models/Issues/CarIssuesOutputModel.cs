using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Issues
{
    public class CarIssuesOutputModel
    {
        public string Id { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public bool UserIsMechanic { get; init; }

        public IEnumerable<IssueOutputModel> Issues = new HashSet<IssueOutputModel>();

    }
}
