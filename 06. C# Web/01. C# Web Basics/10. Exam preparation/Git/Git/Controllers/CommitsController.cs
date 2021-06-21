﻿using Git.Data.Models;
using Git.Models.Commits;
using Git.Models.Repositories;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly GitDbContext db;
        private readonly IValidator validator;

        public CommitsController(GitDbContext db, IValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repo = this.db
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            if (repo==null)
            {
                return BadRequest();

            }
            return View(repo);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CommitCreateModel model)
        {
            if (this.db.Repositories.Any(r=>r.Id==model.Id))
            {
                return BadRequest(); //Should be NotFound!

            }
            var modelErrors = validator.ValidateCommitCreation(model);
            if (modelErrors.Count > 0)
            {
                return Error(modelErrors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow.ToLocalTime(),//??
                CreatorId = this.User.Id,
                RepositoryId = model.Id
            };
            this.db.Commits.Add(commit);
            this.db.SaveChanges();
            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.db
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new AllCommitsViewModel
                {
                    Id = c.Id,
                    RepositoryName = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("F")
                })
                .ToList();

            return View(commits);

        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.db
                .Commits
                .Where(c => c.Id == id && c.CreatorId == this.User.Id)
                .FirstOrDefault();

            if (commit == null)
            {
                return BadRequest();
            }

            this.db.Commits.Remove(commit);
            db.SaveChanges();

            return this.Redirect("/Commits/All");

        }
    }
}
