USE [$(DatabaseName)]

IF DATABASE_PRINCIPAL_ID('srvc_saga_s') IS NULL
BEGIN
	CREATE LOGIN [srvc_saga_s] WITH PASSWORD = 'saga1';
	CREATE USER [srvc_saga_s] FOR LOGIN [srvc_saga_s]
END

ALTER USER [srvc_saga_s] WITH DEFAULT_SCHEMA = [dbo]

IF DATABASE_PRINCIPAL_ID('Role_Saga_App') IS NULL
BEGIN
	CREATE ROLE [Role_Saga_App] AUTHORIZATION [dbo]
END

ALTER ROLE [Role_Saga_App] ADD MEMBER [srvc_saga_s]

GRANT EXECUTE ON SCHEMA::[dbo] TO [Role_Saga_App]
GRANT ALTER ON SCHEMA::[dbo] TO [Role_Saga_App]
GRANT REFERENCES ON SCHEMA::[dbo] TO [Role_Saga_App]

ALTER ROLE db_datareader ADD MEMBER [srvc_saga_s]
ALTER ROLE db_datawriter ADD MEMBER [srvc_saga_s]