CREATE TABLE [dbo].[Articles] (
    [ArticleId]     INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [AuthorId]      INT           NOT NULL,
    [Title]         VARCHAR (255) NOT NULL,
    [Summary]       VARCHAR (255) NOT NULL,
    [Body]          VARCHAR (MAX) NOT NULL,
    [PublishedDate] DATETIME      NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([ArticleId] ASC),
    CONSTRAINT [FK_Articles_Employees] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Employees] ([EmployeeId])
);

