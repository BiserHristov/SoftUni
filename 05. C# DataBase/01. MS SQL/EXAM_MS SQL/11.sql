CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	 RETURN (SELECT COUNT(*) FROM Users u
	JOIN Commits c ON c.ContributorId=u.Id
	WHERE u.Username=@username)
	   	
END