CREATE OR ALTER PROCEDURE Recipes.FetchSteps
	@recipeID int
AS

select S.StepNumber,S.StepDescription
from Recipes.Steps S
where recipeID = @recipeID;

GO
