USE Clinic
BEGIN TRAN
UPDATE Doctor SET [First Name] = 'Pop' WHERE DoctorID = 1
WAITFOR DELAY '00:00:02'
UPDATE Nurse SET [First Name] = 'Ana' WHERE NurseID = 3
COMMIT TRAN