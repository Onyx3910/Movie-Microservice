CREATE TABLE [dbo].[TicketState]
(
	[CorrelationId] UNIQUEIDENTIFIER NOT NULL, 
    [CurrentState] NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_TicketState] PRIMARY KEY ([CorrelationId]), 
    [LastUpdatedDate] DATETIME NULL 
)
