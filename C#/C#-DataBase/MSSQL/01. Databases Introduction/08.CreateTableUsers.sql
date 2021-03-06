CREATE DATABASE Users

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users 
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Gosho', 'pass123', NULL, '1/1/2021',0),
('GLosho', 'pass1234', NULL, '12/12/2011',0),
('GRosho', 'pass1235', NULL, '11/20/2013',0),
('Gnosho', 'pass1236', NULL, '8/30/2019',0),
('Gmosho', 'pass1237', NULL, '1/24/2021',0)

--DELETE KEYS
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0711416B17

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id, Username)

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) > 5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols CHECK (LEN(Username) > 3)