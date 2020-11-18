CREATE OR ALTER PROCEDURE Recipes.FetchStars
	@RecipeId INT
AS


select HR.Stars
	from Recipes.HistoryOfUsedRecipes HR
	where RecipeID=@RecipeID
go