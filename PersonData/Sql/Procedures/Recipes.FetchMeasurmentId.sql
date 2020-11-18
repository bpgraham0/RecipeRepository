CREATE OR ALTER PROCEDURE Recipes.FetchMeasurementLIst
@Name NVARCHAR(64),
@MeasurementId  int output
AS

select @MeasurementId=MeasurementId,[Name]
from Recipes.Measurements M

GO




