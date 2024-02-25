PRINT 'Starting Post Deployment Script'

IF N'$(Environment)' LIKE N'Stage'
BEGIN
	PRINT 'Stage Environment'
	PRINT '-----------------'

	PRINT 'Granting Execute Read Write'
	:r .\Post-Deployment\DBProperties\Stage\GrantExecute_Read_Write.sql

	PRINT 'Changing to full recovery mode'
	:r .\Post-Deployment\DBProperties\Stage\SetDBRecoveryMode.sql
END
IF N'$(Environment)' LIKE N'Prod'
BEGIN
	PRINT 'Prod Environment'
	-- Prod Environment
	-- Do something
END
IF N'$(RunSeedData)' LIKE N'True'
BEGIN
	PRINT 'Inserting Seed Data'
	PRINT '-----------------'

	PRINT 'Inserting Status Seed Data'
	:r .\Post-Deployment\SeedData\StatusSeedData.sql
END