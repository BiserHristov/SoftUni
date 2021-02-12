SELECT d.Name,i.Name,p.Name,AVG(f.Rate) as AvgRate FROM Products p
 JOIN Feedbacks f ON f.ProductId=p.Id
 JOIN ProductsIngredients poIn ON poIn.ProductId=p.Id
 JOIN Ingredients i ON i.Id=poIn.IngredientId
 JOIN Distributors d ON d.Id=i.DistributorId
 GROUP BY d.Name,i.Name,p.Name
 HAVING AVG(f.Rate) BETWEEN 5 AND 8
 ORDER BY d.Name, i.Name, p.Name
