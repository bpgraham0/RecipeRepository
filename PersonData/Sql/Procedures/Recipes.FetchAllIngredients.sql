CREATE OR ALTER PROCEDURE Recipes.FetchAllIngredients
AS

select I.ingredientid, I.Name, I.HaveItem
from Recipes.ingredient I

GO
