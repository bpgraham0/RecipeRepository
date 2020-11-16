IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'Recipes'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [Recipes] AUTHORIZATION [dbo]');
END;
