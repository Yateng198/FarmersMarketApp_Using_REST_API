CREATE TABLE [dbo].[ProductTable] (
    [ProductID]   INT          NOT NULL,
    [ProductName] VARCHAR (50) NOT NULL,
    [Amount]      INT   NULL,
    [Price]       DECIMAL(6,2) NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

