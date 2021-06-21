using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models.Commits
{
    public class AllCommitsViewModel
    {
        public string Id { get; init; }
        public string RepositoryName { get; init; }
        public string Description { get; init; }
        public string CreatedOn { get; init; }
    }
}
