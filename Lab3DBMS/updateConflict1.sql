USE Clinic

BEGIN TRAN
SELECT * FROM Doctor
UPDATE Doctor SET Salary = Salary+10 WHERE DoctorID = 1
SELECT * FROM Doctor
WAITFOR DELAY '00:00:05'
COMMIT TRAN
