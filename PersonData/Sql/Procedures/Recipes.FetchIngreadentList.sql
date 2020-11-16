CREATE OR ALTER PROCEDURE Recipes.FetchIngredientList
	@recipeID int
AS

select I.name, IL.quanity,M.name, I.HaveItem
from Recipes.IngredientList IL
Inner Join Recipes.Ingredients I ON  I.IngredientId = IL.IngredientId
Inner Join Recipes.Measurements M ON  M.MeasurementID = IL.MeasurementID
where recipeID = @recipeID;

GO
