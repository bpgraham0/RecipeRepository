CREATE OR ALTER PROCEDURE Recipes.FetchStars
	@RecipeId INT,
	@stars int output
AS


select @stars=HR.Stars
	from Recipes.HistoryOfUsedRecipes HR
	where RecipeID=@RecipeID
go