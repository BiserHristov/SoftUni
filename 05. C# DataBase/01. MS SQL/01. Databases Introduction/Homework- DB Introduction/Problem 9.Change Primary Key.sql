
--Using SQL queries modify table Users from the previous task. 
--First remove current primary key then create new primary key that would be the combination of fields Id and Username.

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07F01985FA;

ALTER TABLE Users
ADD CONSTRAINT PK_Id_Username
PRIMARY KEY (Id, Username) 
