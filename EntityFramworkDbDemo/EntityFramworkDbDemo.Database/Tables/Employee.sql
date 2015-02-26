CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [GUID] VARCHAR(MAX) NOT NULL DEFAULT NEWID(), 
    [Name] VARCHAR(MAX) NOT NULL, 
    [EmailID] VARCHAR(MAX) NOT NULL, 
    [DepartmentId] INT NOT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT getdate(), 
    [IsDeleted] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_Employee_ToTable] FOREIGN KEY (DepartmentId) REFERENCES [Department]([Id])
)
