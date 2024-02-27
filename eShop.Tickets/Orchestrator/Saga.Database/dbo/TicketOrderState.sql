CREATE TABLE [dbo].[TicketOrderState]
(
	[CorrelationId] UNIQUEIDENTIFIER NOT NULL, 
    [CurrentState] NVARCHAR(50) NOT NULL,
	[TheaterId] UNIQUEIDENTIFIER NOT NULL,
	[MovieId] UNIQUEIDENTIFIER NOT NULL,
	[Showtime] DATETIME NOT NULL,
	[Seats] XML NULL,
	[LastUpdatedDate] DATETIME NOT NULL, 
	[CreationDate] DATETIME NOT NULL,
	CONSTRAINT [PK_TicketState] PRIMARY KEY ([CorrelationId]), 
)
