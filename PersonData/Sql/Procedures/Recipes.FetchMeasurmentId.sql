
CREATE OR ALTER PROCEDURE Recipes.FetchMeasurementList
AS

select M.MeasurementId, M.[Name]
from Recipes.Measurement M

GO