USE Clinic

BEGIN TRAN
UPDATE Nurse SET [First Name] = 'Ana Maria' WHERE NurseID = 3
WAITFOR DELAY '00:00:02'
UPDATE Doctor SET [First Name] = 'Popescu' WHERE DoctorID = 1
COMMIT TRAN