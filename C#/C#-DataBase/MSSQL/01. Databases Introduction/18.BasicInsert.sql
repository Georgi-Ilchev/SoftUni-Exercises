USE SoftUni

INSERT INTO Towns ([Name])
VALUES ('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO Departments ([Name])
VALUES ('Engineering,'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova','Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov','CEO', 2, '2007-12-09', 3000),
('Peter', 'Pan', 'Pan','.NET Developer', 3, '2016-08-28', 599.88)