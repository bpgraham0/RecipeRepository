CREATE OR ALTER PROCEDURE Recipes.FetchAllIngredients
AS

select I.Name
from Recipes.ingredient I

GO
