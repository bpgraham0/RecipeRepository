
CREATE OR ALTER PROCEDURE  Recipes.AddToIngredientList
	@RecipeID INT,
	@IngredientID INT,
	@MeasurementID INT,
	@quanity INT
AS
INSERT Recipes.ingredientList(RecipeId,IngredientId,MeasurementId,Quantity)
SELECT  @RecipeID,@IngredientID,@MeasurementID,@quanity
WHERE   NOT EXISTS 
	(select 1
	from Recipes.ingredientList
	where RecipeID=@RecipeID
	And IngredientID=@IngredientID
	);
GO