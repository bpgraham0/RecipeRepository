CREATE OR ALTER PROCEDURE Recipes.FetchFoodType
	@recipeID int,
	@Name NVARCHAR(64) output
AS

select @Name=FT.Name
from Recipes.Recipe R
Inner Join  Recipes.FoodType FT ON R.FoodTypeID = FT.FoodTypeID
where recipeID = @recipeID;

GO
