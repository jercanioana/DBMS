USE Clinic

ALTER DATABASE Clinic
SET READ_COMMITTED_SNAPSHOT ON
BEGIN TRAN
Select * from Doctor
UPDATE Doctor SET Salary = Salary+15 WHERE DoctorID = 1
Select * from Doctor
COMMIT TRAN


