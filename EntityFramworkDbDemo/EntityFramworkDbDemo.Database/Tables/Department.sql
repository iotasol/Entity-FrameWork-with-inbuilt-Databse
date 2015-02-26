CREATE TABLE [dbo].[Department] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [GUID]      VARCHAR (MAX) DEFAULT (newid()) NOT NULL,
    [Name]      VARCHAR (MAX) NOT NULL,
    [DepartmentCode] VARCHAR(MAX) NOT NULL, 
    [CreatedOn] DATETIME      DEFAULT (getdate()) NOT NULL,
    [IsDeleted] BIT           DEFAULT 0 NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


