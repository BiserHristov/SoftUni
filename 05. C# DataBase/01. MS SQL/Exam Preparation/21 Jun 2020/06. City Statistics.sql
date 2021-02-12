SELECT c.Name, COUNT(*) AS HotelCount FROM Hotels h
	 JOIN Cities c ON c.Id= h.CityId
 GROUP BY c.Name
 ORDER BY HotelCount DESC, c.Name

