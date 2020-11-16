CREATE OR ALTER PROCEDURE Recipes.RecentRecipesSorted
AS


if EXISTS 
	(select *
	from Recipes.HistoryOfUsedRecipes
	where RecipeID=@RecipeID
	)
begin
Update Recipes.HistoryOfUsedRecipes
set 
	Stars = @Stars,
	LastDateUsed = @LastDateUsed
where  RecipeID=@RecipeID;
end
else 
begin
INSERT Recipes.HistoryOfUsedRecipes(RecipeId, LastDateUsed,Stars)
VALUES (@RecipeId,@LastDateUsed,@Stars)
end
GO

