USE Clinic

GO
CREATE OR ALTER PROCEDURE usp_insertTrans (@diagnosis varchar(50), @dName VARCHAR(30), @pName VARCHAR(30), @date date)  AS

--BEGIN TRAN insertData
	
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
		--COMMIT TRAN  insertData
	END TRY
	BEGIN CATCH
		print('Invalid')
		raiserror('invalid', 14, 1)
		--ROLLBACK TRAN insertData
	END CATCH

GO

go
CREATE OR ALTER PROCEDURE insertGood 
AS
	BEGIN TRAN
	BEGIN TRY
		EXEC usp_insertTrans 'c1','Ionescu','Pop', '10-10-10'
		EXEC usp_insertTrans 'c2', 'Ionescu', 'Teo', '10-10-10'
		EXEC usp_insertTrans 'c3', 'Andronache', 'Marin', '10-10-10'
		print('Added all 3 records!')
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		print('Rolled back')
		ROLLBACK TRAN
	END CATCH
	
go
GO
CREATE OR ALTER PROCEDURE insertBad 
AS
	BEGIN TRAN
	BEGIN TRY
		EXEC usp_insertTrans 'c3', 'Andronache', 'Arcas', '10-10-10'
		EXEC usp_insertTrans 'c1', 'Ionescu','Pop', '10-10-10'
		EXEC usp_insertTrans 'c2', 'Ionescu', 'Teo', '10-10-10'
		print('Added all 3 records!')
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		print('Rolled back')
		ROLLBACK TRAN
	END CATCH
	
go

EXEC insertGood
SELECT * FROM Consultation
DELETE FROM Consultation
EXEC insertBad
SELECT * FROM Consultation