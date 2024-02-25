CREATE TABLE [dbo].[Log]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
    [StatusId] INT NOT NULL,
    [CorrelationId] UNIQUEIDENTIFIER NOT NULL,
    [Message] NCHAR(10) NULL,
    [Timestamp] DATETIME NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Log] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Log_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id])
)
