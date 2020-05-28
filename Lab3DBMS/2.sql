USE Clinic

GO
CREATE OR ALTER PROCEDURE usp_insertPatient (@fname VARCHAR(50), @lname VARCHAR(50), @gender VARCHAR(20), @age tinyint, @date1 Date, @nName VARCHAR(30), @date2 Date)  AS

BEGIN TRAN insertData
	
	BEGIN TRY
		DECLARE @NID TINYINT
		IF NOT EXISTS (SELECT * FROM Nurse WHERE [Last Name] = @nName)
			RAISERROR('No such nurse', 14, 1)
		SET @NID = (SELECT NurseID FROM Nurse WHERE [Last Name] = @nName)
		IF EXISTS (SELECT * FROM Patient WHERE [First Name] = @fname AND [Last Name] = @lname)
			RAISERROR('Patient already exists', 14,1)
		IF (@gender != 'F' and @gender != 'M')
			RAISERROR('Gender not valid',14,1)
		INSERT INTO Patient([First Name],[Last Name],Gender,Age,[Date of check in],NurseID,[Date of check out]) VALUES (@fname, @lname, @gender, @age, @date1, @NID, @date2)
		COMMIT TRAN  insertData
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN insertData
	END CATCH

GO
CREATE OR ALTER PROCEDURE usp_insertDoctor (@fname VARCHAR(50), @lname VARCHAR(50), @gender VARCHAR(20), @age tinyint, @section VARCHAR(50), @Salary DECIMAL(8,2))  AS

BEGIN TRAN 
	
	BEGIN TRY
		IF EXISTS (SELECT * FROM Doctor WHERE [First Name] = @fname AND [Last Name] = @lname)
			RAISERROR('Doctor already exists', 14,1)
		IF (@gender != 'F' and @gender != 'M')
			RAISERROR('Gender not valid',14,1)
		INSERT INTO Doctor([First Name],[Last Name],Gender,Age,Section,Salary) VALUES (@fname, @lname, @gender, @age,@section,@Salary)
		COMMIT TRAN  
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN 
	END CATCH

GO
CREATE OR ALTER PROCEDURE usp_insertTrans (@diagnosis varchar(50), @dName VARCHAR(30), @pName VARCHAR(30), @date date)  AS

BEGIN TRAN insertData
	
	BEGIN TRY
		DECLARE @PID TINYINT
		DECLARE @DID TINYINT
		IF NOT EXISTS (SELECT * FROM Doctor WHERE [Last Name] = @dName)
			begin
				RAISERROR('Invalid doctor id', 14, 1)
			end
		IF NOT EXISTS (SELECT * FROM Patient WHERE [Last Name] = @pName)
			begin
				RAISERROR('Invalid patient id', 14, 1)
			end
		SET @PID = (SELECT PatientID FROM Patient WHERE [Last Name] = @pName)
		SET @DID = (SELECT DoctorID FROM Doctor WHERE [Last Name] = @dName)
		IF EXISTS (SELECT * FROM Consultation WHERE PatientID = @PID AND DoctorID = @DID)
			begin
				RAISERROR('Consultation already exists', 14,1)
			end
		
		INSERT INTO Consultation(Diagnosis, DoctorID, PatientID, Date) VALUES (@diagnosis, @DID, @PID, @date)
		print('Added in consultation')
		COMMIT TRAN  insertData
	END TRY
	BEGIN CATCH
		print('Invalid')
		ROLLBACK TRAN insertData
		raiserror('invalid', 14, 1)
		
	END CATCH

GO
CREATE OR ALTER PROCEDURE insertGood 
AS
	begin try
			EXEC usp_insertPatient 'a', 'lname1', 'F', 20, '10-10-10', 'Vasiliu', '10-10-10'
			EXEC usp_insertPatient 'a', 'lname2', 'F', 20, '10-10-10', 'Vasiliu', '10-10-10'
			EXEC usp_insertPatient 'a', 'lname3', 'F', 20, '10-10-10', 'Vasiliu', '10-10-10'
			EXEC usp_insertDoctor 'a', 'lname4', 'M', 40, 's', 1000
			EXEC usp_insertTrans 'd1', 'lname4', 'lname1', '9-9-9'
			EXEC usp_insertTrans 'd1', 'lname4', 'lname2', '9-9-9'
			EXEC usp_insertTrans 'd1', 'lname4', 'lname3', '9-9-9'
			print('All the records were added')
	end try
	begin catch
		print('Rolled back')
	end catch
		
	
go
GO
CREATE OR ALTER PROCEDURE insertBad 
AS
	begin try		
			EXEC usp_insertPatient 'a', 'lname1', 'F', 20, '10-10-10', 'Vasiliu', '10-10-10'
			EXEC usp_insertPatient 'a', 'lname2', 'F', 20, '10-10-10', 'Vasiliu', '10-10-10'
			EXEC usp_insertPatient 'a', 'lname3', 'F', 20, '10-10-10', 'Vasiliu', '10-10-10'
			EXEC usp_insertDoctor 'a', 'lname4', 'G', 40, 's', 1000
			EXEC usp_insertTrans 'd1', 'lname4', 'lname1', '9-9-9'
			EXEC usp_insertTrans 'd1', 'lname4', 'lname2', '9-9-9'
			EXEC usp_insertTrans 'd1', 'lname4', 'lname3', '9-9-9'
			print('All the records were added')
	end try
	begin catch
		print('Rolled back')
	end catch
	
go
EXEC insertGood
SELECT * FROM Doctor
SELECT * FROM Patient
SELECT * FROM Consultation
DELETE FROM Consultation
DELETE FROM Doctor WHERE [Last Name] = 'lname4'
DELETE FROM Patient WHERE [Last Name] IN ('lname1', 'lname2', 'lname3')
EXEC insertBad
SELECT * FROM Doctor
SELECT * FROM Patient
SELECT * FROM Consultation
DELETE FROM Patient WHERE [Last Name] IN ('lname1', 'lname2', 'lname3')