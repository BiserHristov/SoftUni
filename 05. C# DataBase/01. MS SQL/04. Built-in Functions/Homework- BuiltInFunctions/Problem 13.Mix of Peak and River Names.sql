SELECT p.PeakName, r.RiverName, LOWER(SUBSTRING(p.PeakName, 1,LEN(p.PeakName)-1) + r.RiverName ) AS 'Mix' FROM Rivers r
CROSS JOIN Peaks p
WHERE RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
ORDER BY Mix