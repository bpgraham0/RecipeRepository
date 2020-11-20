CREATE OR ALTER PROCEDURE Recipes.FetchAllIngredients
AS

select I.IngredientId, I.Name, I.HaveItem
from Recipes.ingredient I

GO
