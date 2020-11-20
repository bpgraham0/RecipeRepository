CREATE OR ALTER PROCEDURE Recipes.FetchIngredientList
	@recipeID int
AS

select I.IngredientId ,I.name, IL.quantity, M.name, I.HaveItem
from Recipes.IngredientList IL
Inner Join Recipes.Ingredient I ON  I.IngredientId = IL.IngredientId
Inner Join Recipes.Measurement M ON  M.MeasurementID = IL.MeasurementID
where recipeID = @recipeID;

GO
