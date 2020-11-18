
CREATE OR ALTER PROCEDURE  Recipes.DeleteStep
	@RecipeID INT,
	@StepNumber INT

AS
delete From Recipes.Steps  
Where recipeID=@RecipeID
and StepNumber=@StepNumber ;

GO