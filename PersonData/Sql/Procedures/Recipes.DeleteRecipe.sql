
CREATE OR ALTER PROCEDURE Recipes.DeleteRecipe
	@RecipeId INt 
AS	
	DELETE FROM Recipes.IngredientList
		WHERE EXISTS
			(SELECT *
			from IngredientList I
			WHERE I.RecipeID=@RecipeId);
	DELETE FROM Recipes.Steps
		WHERE EXISTS
			(SELECT *
			from Recipes.Steps s
			WHERE s.RecipeID=@RecipeId);

	DELETE FROM Recipes.HistoryOfUsedRecipes
		WHERE EXISTS
			(SELECT *
			from Recipes.HistoryOfUsedRecipes h
			WHERE h.RecipeID=@RecipeId);
	DELETE FROM Recipes.Recipe
		WHERE EXISTS
			(SELECT *
			from Recipes.Recipe r
			WHERE r.RecipeID=@RecipeId);
go