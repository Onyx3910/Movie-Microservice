USE [$(DatabaseName)]

IF DATABASE_PRINCIPAL_ID('srvc_audit_s') IS NULL
BEGIN
	CREATE LOGIN [srvc_audit_s] WITH PASSWORD = 'audit1';
	CREATE USER [srvc_audit_s] FOR LOGIN [srvc_audit_s]
END

ALTER USER [srvc_audit_s] WITH DEFAULT_SCHEMA = [dbo]

IF DATABASE_PRINCIPAL_ID('Role_Audit_App') IS NULL
BEGIN
	CREATE ROLE [Role_Audit_App] AUTHORIZATION [dbo]
END

ALTER ROLE [Role_Audit_App] ADD MEMBER [srvc_audit_s]

GRANT EXECUTE ON SCHEMA::[dbo] TO [Role_Audit_App]
GRANT ALTER ON SCHEMA::[dbo] TO [Role_Audit_App]
GRANT REFERENCES ON SCHEMA::[dbo] TO [Role_Audit_App]

ALTER ROLE db_datareader ADD MEMBER [srvc_audit_s]
ALTER ROLE db_datawriter ADD MEMBER [srvc_audit_s]