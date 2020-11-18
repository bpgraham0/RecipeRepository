CREATE OR ALTER PROCEDURE Recipes.FetchHistory
	@recipeID int
AS

select R.name, HR.Stars,Hr.LastDateUsed
from Recipes.HistoryOfUsedRecipes HR
Inner Join Recipes.Recipe R On R.RecipeID = HR.RecipeID
where recipeID = @recipeID;

GO
