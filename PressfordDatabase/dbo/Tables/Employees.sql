CREATE TABLE [dbo].[Employees] (
    [EmployeeId]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]         NVARCHAR (256) NOT NULL,
    [FirstName]        VARCHAR (50)   NOT NULL,
    [LastName]         VARCHAR (50)   NOT NULL,
    [MaxLikesPerMonth] INT            CONSTRAINT [DF_Employees_MaxLikesPerMonth] DEFAULT ((5)) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

