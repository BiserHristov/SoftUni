
SELECT TOP(5) r.Id, r.Name, COUNT(*) AS TotalCommits FROM RepositoriesContributors rc
JOIN Repositories r ON r.Id=rc.RepositoryId
JOIN Commits c ON c.RepositoryId=r.Id
GROUP BY  r.Id,r.Name
ORDER BY TotalCommits DESC, r.Id,r.Name