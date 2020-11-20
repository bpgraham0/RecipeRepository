
CREATE OR ALTER PROCEDURE Recipes.FetchMeasurementId
@Name NVARCHAR(64),
@MeasurementId  int output
AS

select @MeasurementId=M.MeasurementId
from Recipes.Measurement M
where M.[Name]=@Name;
GO