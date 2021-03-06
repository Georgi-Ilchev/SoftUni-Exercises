CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR (50) NOT NULL,
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT NOT NULL,

	CONSTRAINT FK_Addresses_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR (50) NOT NULL,
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR (30) NOT NULL,
	MiddleName VARCHAR (30) NOT NULL,
	LastName VARCHAR (30) NOT NULL,
	JobTitle VARCHAR (30) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL (7,2) NOT NULL,
	AddressId INT

	CONSTRAINT FK_Employees_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),

	CONSTRAINT FK_Employees_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses(Id)

	--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
)
