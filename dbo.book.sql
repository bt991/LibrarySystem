CREATE TABLE [dbo].[book] (
    [bookCode]      INT         NOT NULL,
    [title]         CHAR (40)   NOT NULL,
    [authorNum]     DECIMAL (2) NOT NULL,
    [publisherCode] CHAR (3)    NOT NULL,
    [genre]         CHAR (3)    NOT NULL,
    [inStock]       CHAR (1)    NOT NULL,
    PRIMARY KEY CLUSTERED ([bookCode] ASC)
);

