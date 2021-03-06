﻿
CREATE OR ALTER PROCEDURE Recipes.AddToHistoryOfUsedRecipes
	@RecipeId INT,
	@Stars Float(53)
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
	LastDateUsed = GETDATE()
where  RecipeID=@RecipeID;
end
else 
begin
INSERT Recipes.HistoryOfUsedRecipes(RecipeId, LastDateUsed,Stars)
VALUES (@RecipeId,GETDATE(),@Stars)
end
GO