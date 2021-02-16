
DELETE RepositoriesContributors
WHERE RepositoryId=(SELECT Id FROM Repositories
					WHERE [Name]='Softuni-Teamwork')

DELETE Issues
WHERE RepositoryId=(SELECT Id FROM Repositories
					WHERE [Name]='Softuni-Teamwork')
					