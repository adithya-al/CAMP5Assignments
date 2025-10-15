CREATE DATABASE camp5db;
Use camp5db;

CREATE TABLE Membership(
MemberId INT PRIMARY KEY IDENTITY(1,1),
MemberDescrip NVARCHAR(30) NOT NULL,
InsureAmt DECIMAL(10,2) NOT NULL CHECK (InsureAmt >=0)
);
SELECT * FROM Membership;
SELECT * FROM Patients;
EXEC sp_GetAllPatients;

CREATE TABLE Patients(
PatientId INT PRIMARY KEY IDENTITY(1,1),
RegisterNo NVARCHAR(10) NOT NULL,
PatientName NVARCHAR(25) NOT NULL,
DOB DATETIME NOT NULL,
Gender NVARCHAR(10) NOT NULL CHECK (Gender IN ('Male','Female','Other')),
Address NVARCHAR(50) NOT NULL,
PhoneNo NVARCHAR(10) NOT NULL,
MemberId INT NOT NULL,
CONSTRAINT FK_Patient_Membership FOREIGN KEY (MemberId) REFERENCES Membership(MemberId) ON DELETE CASCADE
);


SELECT * FROM Patients;
--Insert valkues

INSERT INTO Membership (MemberDescrip, InsureAmt)
VALUES ('Basic Plan', 5000.00);

INSERT INTO Membership (MemberDescrip, InsureAmt)
VALUES ('Premium Plan', 10000.00);

--Patients
INSERT INTO Patients (RegisterNo, PatientName, DOB, Gender, Address, PhoneNo, MemberId)
VALUES ('REG001', 'Adithya', '2000-05-20', 'Male', 'Bangalore', '9876543210', 1);

INSERT INTO Patients (RegisterNo, PatientName, DOB, Gender, Address, PhoneNo, MemberId)
VALUES ('REG002', 'Gayathri', '1999-10-15', 'Female', 'Chennai', '9123456780', 2);

INSERT INTO Patients (RegisterNo, PatientName, DOB, Gender, Address, PhoneNo, MemberId)
VALUES ('REG003', 'Vishnu', '2001-08-25', 'Male', 'Hyderabad', '9988776655', 1);

INSERT INTO Patients (RegisterNo, PatientName, DOB, Gender, Address, PhoneNo, MemberId)
VALUES ('REG004', 'Priya', '2002-03-10', 'Female', 'Coimbatore', '9090909090', 2);

INSERT INTO Patients (RegisterNo, PatientName, DOB, Gender, Address, PhoneNo, MemberId)
VALUES ('REG005', 'Rahul', '1998-11-05', 'Male', 'Mysore', '9876501234', 1);


-->Stored Procedure
CREATE PROCEDURE sp_GetAllPatients
AS BEGIN
SET NOCOUNT ON;
SELECT 
	P.PatientId,
	P.RegisterNo,
	P.PatientName,
	P.DOB,
	P.Gender,
	P.Address,
	P.PhoneNo,
	P.MemberId,
	M.MemberDescrip,
	M.InsureAmt
FROM Patients P INNER JOIN Membership M ON P.MemberId = M.MemberId
ORDER BY P.PatientId;
End;

--Stored Procedure for Add Patient
CREATE PROCEDURE [dbo].[sp_AddPatient]
@RegisterNo NVARCHAR(10),
@PatientName NVARCHAR(50),
@DOB DATETIME,
@Gender NVARCHAR(20),
@Address NVARCHAR(50),
@PhoneNo NVARCHAR(10),
@MemberId INT
AS
BEGIN
INSERT INTO Patients(RegisterNo,PatientName,DOB,Gender,Address,PhoneNo,MemberId)
VALUES(@RegisterNo,@PatientName,@DOB,@Gender,@Address,@PhoneNo,@MemberId)
END;

CREATE PROCEDURE sp_SelectAllMembership 
AS BEGIN 
SELECT MemberId,MemberDescrip,InsureAmt 
FROM Membership;
END;

--Edit and Update

Create Procedure [dbo].[sp_EditPatient]
@PatientId INT,
@RegisterNo NVARCHAR(10),
@PatientName NVARCHAR(50),
@DOB DATETIME,
@Gender NVARCHAR(20),
@Address NVARCHAR(50),
@PhoneNo NVARCHAR(10),
@MemberId INT
AS
BEGIN
	UPDATE Patients
	SET PatientName = @PatientName,
	DOB = @DOB,
	Gender = @Gender,
	Address = @Address,
	PhoneNo = @PhoneNo,
	MemberId = @MemberId
	WHERE PatientId = @PatientId
	END;

-- search Patient by id
Create Procedure [dbo].[sp_GetPatientById]
(
@PatientId int
)
AS
BEGIN 
SELECT *from Patients where PatientId=@PatientId
END;





-->2nd Assignment

Create Table Department(
DepartmentId INT PRIMARY KEY IDENTITY(1,1),
DepartmentName NVARCHAR(30) NOT NULL);



CREATE Table Professor(
ProfessorId INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20)NOT NULL,
Salary DECIMAL(10,2)NOT NULL,
DateOfBirth DATETIME NOT NULL,
Gender NVARCHAR(10) NOT NULL CHECK (Gender IN ('Male','Female','Other')),
JoinDate DATETIME NOT NULL,
HOD NVARCHAR(20) NOT NULL,
DepartmentId INT
CONSTRAINT FK_Professor_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId) ON DELETE CASCADE
);
-->Department insert values
INSERT INTO Department (DepartmentName) VALUES ('Computer Science');
INSERT INTO Department (DepartmentName) VALUES ('Mathematics');
INSERT INTO Department (DepartmentName) VALUES ('Physics');
INSERT INTO Department (DepartmentName) VALUES ('Chemistry');
INSERT INTO Department (DepartmentName) VALUES ('English');
select *from Department
--Inserting
INSERT INTO Professor (FirstName, LastName, Salary, DateOfBirth, Gender, JoinDate, HOD, DepartmentId) 
VALUES ('Rajesh', 'Patil', 75000.00, '1978-03-25', 'Male', '2008-05-10', 'Dr. Adithya Kumar', 1);

INSERT INTO Professor (FirstName, LastName, Salary, DateOfBirth, Gender, JoinDate, HOD, DepartmentId) 
VALUES ('Meera', 'Desai', 72000.00, '1979-11-12', 'Female', '2009-08-15', 'Dr. Gayathri Rao', 2);

INSERT INTO Professor (FirstName, LastName, Salary, DateOfBirth, Gender, JoinDate, HOD, DepartmentId) 
VALUES ('Arun', 'Joshi', 68000.00, '1981-07-08', 'Male', '2011-02-20', 'Dr. Vishnu Menon', 3);

INSERT INTO Professor (FirstName, LastName, Salary, DateOfBirth, Gender, JoinDate, HOD, DepartmentId) 
VALUES ('Priyanka', 'Reddy', 71000.00, '1980-09-14', 'Female', '2012-11-05', 'Dr. Priya Srinivasan', 4);

INSERT INTO Professor (FirstName, LastName, Salary, DateOfBirth, Gender, JoinDate, HOD, DepartmentId) 
VALUES ('Suresh', 'Iyer', 69000.00, '1982-12-30', 'Male', '2013-07-18', 'Dr. Rahul Varma', 5);

Select * FROM Professor;

-->Stored Procedure
CREATE PROCEDURE sp_GetAllProfessor
AS BEGIN
SET NOCOUNT ON;
SELECT 
	P.ProfessorId,
	P.FirstName,
	P.LastName,
	P.DateOfBirth,
	P.Gender,
	P.Salary,	
	P.JoinDate,
	P.HOD,
	D.DepartmentName
FROM Professor P INNER JOIN Department D ON P.DepartmentId = D.DepartmentId
ORDER BY ProfessorId;
END;
EXEC sp_GetAllProfessor;

-- Fix the Add Professor stored procedure
CREATE PROCEDURE sp_AddProfessor
    @FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
    @Salary DECIMAL(10,2),
    @DateOfBirth DATETIME,
    @Gender NVARCHAR(10),
    @JoinDate DATETIME,
    @HOD NVARCHAR(20),
    @DepartmentId INT
AS 
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Professor (FirstName, LastName, Salary, DateOfBirth, Gender, JoinDate, HOD, DepartmentId)
    VALUES (@FirstName, @LastName, @Salary, @DateOfBirth, @Gender, @JoinDate, @HOD, @DepartmentId);
END;

CREATE PROCEDURE sp_SelectAllDepartment
AS BEGIN
SET NOCOUNT ON;
SELECT
DepartmentId,DepartmentName FROM Department
END
--Edit and Update
Create Procedure [dbo].[sp_EditProfessor]
@ProfessorId INT,
@FirstName NVARCHAR(20),
@LastName NVARCHAR(20),
@Salary DECIMAL(10,2),
@DateOfBirth DATETIME,
@Gender NVARCHAR(10),
@JoinDate DATETIME,
@HOD NVARCHAR(20),
@DepartmentId INT
AS
BEGIN
UPDATE Professor
SET
FirstName=@FirstName,
LastName=@LastName,
Salary=@Salary,
DateOfBirth=@DateOfBirth,
Gender = @Gender,
JoinDate=@JoinDate,
HOD=@HOD,
DepartmentId=@DepartmentId
WHERE ProfessorId=@ProfessorId
END;

--Search Professor By id
Create Procedure [dbo].[sp_GetProfessorById]
(@ProfessorId INT)
AS
BEGIN
Select *from Professor WHERE ProfessorId=@ProfessorId
END;




--3rd Asssignment
-- Create Roles table
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);


-- Create Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    [Password] NVARCHAR(100) NOT NULL,
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);


-- Insert roles one by one (SQL Server 2005 compatible)
INSERT INTO Roles (RoleName) VALUES ('Administrator');
INSERT INTO Roles (RoleName) VALUES ('Coordinator');
INSERT INTO Roles (RoleName) VALUES ('Receptionist');


-- Insert users one by one (SQL Server 2005 compatible)
INSERT INTO Users (FullName, Email, [Password], RoleId)
VALUES ('Adithya', 'admin@gmail.com', 'admin123', 1);
GO

INSERT INTO Users (FullName, Email, [Password], RoleId)
VALUES ('Athira', 'coord@gmail.com', 'coord123', 2);
GO

INSERT INTO Users (FullName, Email, [Password], RoleId)
VALUES ('Maya ', 'recept@gmail.com', 'recept123', 3);
GO

--Stored Procedure
Create PROCEDURE sp_RegisterUser
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100),
    @RoleId INT
AS
BEGIN
    INSERT INTO Users (FullName, Email, [Password], RoleId)
    VALUES (@FullName, @Email, @Password, @RoleId);
END;
GO

CREATE PROCEDURE sp_ValidateUser
    @Email NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    SELECT TOP 1 UserId, FullName, Email, [Password], RoleId
    FROM Users
    WHERE Email = @Email AND [Password] = @Password;
END;
GO

CREATE PROCEDURE sp_GetAllRoles
AS
BEGIN
    SELECT RoleId, RoleName FROM Roles;
END;
GO


-