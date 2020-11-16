CREATE OR ALTER PROCEDURE Recipes.FetchCookTime
	@recipeID int
AS

select CookTime
from Recipes.recipe
where recipeID = @recipeID;

GO
