
CREATE OR ALTER PROCEDURE  Recipes.DeleteFromIngredientList
	@RecipeID INT,
	@IngredientID INT

AS
delete From Recipes.ingredientList  
Where recipeID=@RecipeID
and IngredientID=@IngredientID ;

GO