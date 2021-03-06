CREATE DATABASE Hotel


--WORKING
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Title VARCHAR(50),
Notes VARCHAR(MAX)
)
 
INSERT INTO Employees
VALUES
('Velizar', 'Velikov', 'Receptionist', 'Nice customer'),
('Ivan', 'Ivanov', 'Concierge', 'Nice one'),
('Elisaveta', 'Bagriana', 'Cleaner', 'Poetesa')
 
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AccountNumber BIGINT,
FirstName VARCHAR(50),
LastName VARCHAR(50),
PhoneNumber VARCHAR(15),
EmergencyName VARCHAR(150),
EmergencyNumber VARCHAR(15),
Notes VARCHAR(100)
)
 
INSERT INTO Customers
VALUES
(123456789, 'Ginka', 'Shikerova', '359888777888', 'Sistry mi', '7708315342', 'Kinky'),
(123480933, 'Chaika', 'Stavreva', '359888777888', 'Sistry mi', '7708315342', 'Lawer'),
(123454432, 'Mladen', 'Isaev', '359888777888', 'Sistry mi', '7708315342', 'Wants a call girl')
 
CREATE TABLE RoomStatus(
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomStatus BIT,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
(1,'Refill the minibar'),
(2,'Check the towels'),
(3,'Move the bed for couple')
 
CREATE TABLE RoomTypes(
RoomType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')
 
CREATE TABLE BedTypes(
BedType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO BedTypes
VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')
 
CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(6,2),
RoomStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)
 
INSERT INTO Rooms (Rate, Notes)
VALUES
(12,'Free'),
(15, 'Free'),
(23, 'Clean it')
 
CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber BIGINT,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(14,2),
TaxRate DECIMAL(8, 2),
TaxAmount DECIMAL(8, 2),
PaymentTotal DECIMAL(15, 2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged)
VALUES
(1, '12/12/2018', 2000.40),
(2, '12/12/2018', 1500.40),
(3, '12/12/2018', 1000.40)
 
CREATE TABLE Occupancies(
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber BIGINT,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(6,2),
PhoneCharge DECIMAL(6,2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 55.55, 'too'),
(2, 15.55, 'much'),
(3, 35.55, 'typing')




--------------------------------------------------------------------------------------------------------------------------------------------------


--WORKING
CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers
(
	AccountNumber INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	EmergencyName NVARCHAR(20) NOT NULL,
	EmergencyNumber NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(50) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(50) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType NVARCHAR(50) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate DECIMAL(4, 2),
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)

	CONSTRAINT FK_Rooms_RoomType
		FOREIGN KEY (RoomType)
			REFERENCES RoomTypes (RoomType),

	CONSTRAINT FK_Rooms_BedType
		FOREIGN KEY (BedType)
			REFERENCES BedTypes (BedType),

	CONSTRAINT FK_Rooms_RoomStatus
		FOREIGN KEY (RoomStatus)
			REFERENCES RoomStatus (RoomStatus)
)

CREATE TABLE Payments 
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(7, 2) NOT NULL,
	TaxRate DECIMAL(7, 2),
	TaxAmount DECIMAL(7, 2),
	PaymentTotal DECIMAL(7, 2),
	Notes NVARCHAR(MAX)

	CONSTRAINT FK_Payments_EmployeeId
		FOREIGN KEY (EmployeeId)
			REFERENCES Employees (Id),

	CONSTRAINT FK_Payments_AccountNumber
		FOREIGN KEY (AccountNumber)
			REFERENCES Customers (AccountNumber)
)

CREATE TABLE Occupancies
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(7, 2) NOT NULL,
	PhoneCharge DECIMAL(7, 2),
	Notes NVARCHAR(MAX)

	CONSTRAINT FK_Occupancies_EmployeeId
		FOREIGN KEY (EmployeeId)
			REFERENCES Employees (Id),

	CONSTRAINT FK_Occupancies_AccountNumber
		FOREIGN KEY (AccountNumber)
			REFERENCES Customers (AccountNumber),

	CONSTRAINT FK_Occupancies_RoomNumber
		FOREIGN KEY (RoomNumber)
			REFERENCES Rooms (RoomNumber)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
	VALUES ('Ivan','Ivanov','Receptionist','Good Guy'),
		   ('Dimitrichko','Dimitrichev','Cleaner','Funny Guy'),
		   ('Stavri','Stavrev','Boss','Rich Guy')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
	VALUES ('Ivan1', 'Ivanov1', '+123312312311', 'Dimitar1', '+1353462641', 'Rich Guy1'),
		   ('Ivan2', 'Ivanov2', '+123312312312', 'Dimitar2', '+1353462642', 'Rich Guy2'),
		   ('Ivan3', 'Ivanov3', '+123312312313', 'Dimitar3', '+1353462643', 'Rich Guy3')

INSERT INTO RoomStatus (RoomStatus, Notes)
	VALUES ('Dirty', 'Must be cleaned!'),
	       ('Clean', 'Nothing to do.'),
	       ('Very Dirty', 'Must be cleaned soon as possible!!')

INSERT INTO RoomTypes (RoomType, Notes)
	VALUES ('Apartment', 'have fridge'),
		   ('Small room', 'doesn''t have fridge'),
		   ('President Apartment', 'have fridge and air conditioner')

INSERT INTO BedTypes (BedType, Notes)
	VALUES ('Small Bed', '1.20 x 1.40'),
		   ('Medium Bed', '1.40 x 1.60'),
		   ('Big Bed', '1.50 x 2.00')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
	VALUES (1356, 'Apartment', 'Medium Bed', 12.56, 'Clean', 'Cleaned after party.'),
		   (1256, 'Small room', 'Small Bed', 11.56, 'Clean', 'Cleaned after party.'),
		   (5356, 'President Apartment', 'Big Bed', 12.56, 'Dirty', 'Dirty after party.')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
	VALUES (1, '2020-12-01', 1, '2020-12-01', '2020-12-15', 10512.56, 10615.65, 10625.65, 61261.65),
		   (2, '2020-12-01', 2, '2020-12-01', '2020-12-15', 10512.56, 10615.65, 10625.65, 61261.65),
		   (3, '2020-12-01', 3, '2020-12-01', '2020-12-15', 10512.56, 10615.65, 10625.65, 61261.65)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	VALUES (1, '2020-12-15', 1, 1256, 10645.65, 10512.67, 'some note'),
		   (2, '2020-12-15', 2, 1356, 10645.65, 10512.67, 'some note'),
		   (3, '2020-12-15', 3, 5356, 10645.65, 10512.67, 'some note')




------------------------------------------------------------------------------------------------------------------------------------------------------




--NOT WORKING ;(

--CREATE TABLE Employees
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(50) NOT NULL,
--	LastName VARCHAR(50) NOT NULL,
--	Title VARCHAR(50) NOT NULL,
--	Notes VARCHAR(MAX)
--)

--INSERT INTO Employees (FirstName, LastName, Title, Notes)
--	VALUES ('Gosho', 'Goshev', 'Receptionist', 'Nice customer'),
--           ('Ivan', 'Ivanov', 'Concierge', 'random note'),
--           ('GInka', 'Bagriana', 'Cleaner', NULL)

--CREATE TABLE Customers
--(
--	AccountNumber INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(50) NOT NULL,
--	LastName VARCHAR(50) NOT NULL,
--	PhoneNumber CHAR(10) NOT NULL,
--	EmergencyName VARCHAR(90) NOT NULL,
--	EmergencyNumber CHAR(10) NOT NULL,
--	Notes VARCHAR(MAX)
--)

--INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
--	VALUES ('Gencho', 'Shikerova', '1234567891', 'T', '1234567891', 'Kinky'),
--           ('Ivanka', 'Stavreva', '1234567891', 'T', '1234567891', 'Lawer'),
--           ('Uysuf', 'Isaev', '1234567891', 'T', '1234567891', 'Wants a call girl')

--CREATE TABLE RoomStatus
--(
--	RoomStatus VARCHAR(20),
--	Notes VARCHAR(MAX)
--)

--INSERT INTO RoomStatus (RoomStatus, Notes)
--	VALUES ('clean','Refill the minibar'),
--           ('dirty','Check the towels'),
--           ('clean','Move the bed for couple')

--CREATE TABLE RoomTypes
--(
--	RoomType VARCHAR(20),
--	Notes VARCHAR(MAX)
--)

--INSERT INTO RoomTypes (RoomType, Notes)
--	VALUES ('Suite', 'Two beds'),
--           ('Wedding', 'One king size bed'),
--           ('Apartment', 'Up to 3 adults and 2 children')

--CREATE TABLE BedTypes
--(
--	BedType VARCHAR(20) NOT NULL,
--	Notes VARCHAR(MAX)
--)

--INSERT INTO BedTypes (BedType, Notes)
--	VALUES ('single', NULL),
--		   ('double', NULL),
--		   ('trible', NULL)

--CREATE TABLE Rooms
--(
--	RoomNumber INT PRIMARY KEY,
--	RoomType VARCHAR(20) NOT NULL,
--	BedType VARCHAR(20) NOT NULL,
--	Rate INT,
--	RoomStatus VARCHAR(20) NOT NULL,
--	Notes VARCHAR(MAX)

--	--CONSTRAINT FK_Rooms_RoomType FOREIGN KEY (RoomType) REFERENCES RoomTypes (RoomType),

--	--CONSTRAINT FK_Rooms_BedType FOREIGN KEY (BedType) REFERENCES BedTypes (BedType),

--	--CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES RoomStatus (RoomStatus)
--)

--INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--	VALUES (010, 'apartment', 'single', 9, 'Clean', null),
--		   (011, 'xxl-room', 'double', 10, 'Clean', null),
--		   (012, 'business', 'single', 11, 'Clean', null)

----ALTER TABLE Rooms
----DROP CONSTRAINT FK_Rooms_RoomType

----ALTER TABLE Rooms
----DROP CONSTRAINT FK_Rooms_BedType

----ALTER TABLE Rooms
----DROP CONSTRAINT FK_Rooms_RoomStatus

--CREATE TABLE Payments
--(
--	Id INT PRIMARY KEY IDENTITY,
--	EmployeeId INT NOT NULL,
--	PaymentDate DATETIME NOT NULL,
--	AccountNumber INT NOT NULL,
--	FirstDateOccupied DATETIME NOT NULL,
--	LastDateOccupied DATETIME NOT NULL,
--	--TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
--	TotalDays INT NOT NULL,
--	AmountCharged DECIMAL (15,2) NOT NULL,
--	TaxRate INT,
--	TaxAmount INT,
--	PaymentTotal DECIMAL (15,2),
--	Notes VARCHAR(MAX)
--)

--INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
--	VALUES (1, GETDATE(), 1, '2020-12-01', '2020-12-15', 3, 150.56, NULL, NULL, 150.56, NULL),
--		   (2, GETDATE(), 2, '2020-12-01', '2020-12-15', 3, 150.56, NULL, NULL, 150.56, NULL),
--		   (3, GETDATE(), 3, '2020-12-01', '2020-12-15', 3, 150.56, NULL, NULL, 150.56, NULL)


--CREATE TABLE Occupancies
--(
--	Id INT IDENTITY PRIMARY KEY,
--	EmployeeId INT NOT NULL,
--	DateOccupied DATETIME NOT NULL,
--	AccountNumber INT NOT NULL,
--	RoomNumber INT NOT NULL,
--	RateApplied INT,
--	PhoneCharge DECIMAL(15,2),
--	Notes VARCHAR(MAX)

--	CONSTRAINT FK_Occupancies_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
--	CONSTRAINT FK_Occupancies_AccountNumber FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
--	CONSTRAINT FK_Occupancies_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
--)

--INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
--	VALUES (1, GETDATE(), 1, 120, 0, 0, 'some note'),
--		   (2, GETDATE(), 2, 1120, 0, 0, 'some note'),
--		   (3, GETDATE(), 3, 120, 0, 0, 'some note')

--ALTER TABLE Occupancies
--DROP CONSTRAINT FK_Occupancies_EmployeeId

--DROP TABLE Occupancies

--ALTER TABLE Occupancies
--DROP CONSTRAINT FK_Occupancies_AccountNumber

--ALTER TABLE Occupancies
--DROP CONSTRAINT FK_Occupancies_RoomNumber

