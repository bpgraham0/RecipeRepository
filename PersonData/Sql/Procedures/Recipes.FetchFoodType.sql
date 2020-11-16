CREATE OR ALTER PROCEDURE Recipes.FetchFoodType
	@recipeID int
AS

select FT.Name
from Recipes.Recipe R
Inner Join  Recipes.FoodType FT ON R.FoodTypeID = FT.FoodTypeID
where recipeID = @recipeID;

GO
