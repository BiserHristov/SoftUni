SELECT pf.Id, pf.Name,CAST(pf.Size AS VARCHAR)+'KB' AS Size FROM Files pf
LEFT JOIN Files f ON pf.Id=f.ParentId
WHERE f.Id IS NULL
ORDER BY pf.Id, pf.Name,pf.Size DESC
