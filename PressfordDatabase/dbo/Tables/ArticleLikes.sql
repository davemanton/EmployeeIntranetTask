CREATE TABLE [dbo].[ArticleLikes] (
    [ArticleId]   INT      NOT NULL,
    [EmployeeId]  INT      NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    CONSTRAINT [PK_ArticleLikes] PRIMARY KEY CLUSTERED ([ArticleId] ASC, [EmployeeId] ASC),
    CONSTRAINT [FK_ArticleLikes_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([ArticleId]),
    CONSTRAINT [FK_ArticleLikes_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeId])
);

