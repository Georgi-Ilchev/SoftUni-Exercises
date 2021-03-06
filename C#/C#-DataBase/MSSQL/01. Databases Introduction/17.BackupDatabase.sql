BACKUP DATABASE SoftUni TO DISK = 'D:\New folder\Softuni-backup.bak'

USE master

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'D:\New folder\Softuni-backup.bak'