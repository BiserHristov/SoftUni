--Using SQL queries modify table Users. 
--Add check constraint to ensure that the values in the Password field are at least 5 symbols long. 

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password])>=5)

