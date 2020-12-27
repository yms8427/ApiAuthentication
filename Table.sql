USE Northwind
CREATE TABLE Users
(
	UserId int NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserName varchar(20) NOT NULL,
	Password varchar(64) NOT NULL,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	BirthDate date NOT NULL,
	IsActive bit DEFAULT 1,
)
