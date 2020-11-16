CREATE OR ALTER PROCEDURE Recipes.FetchCourceType
	@recipeID int
AS

select CT.Name
from Recipes.Recipe R
Inner Join  Recipes.CourceType CT ON R.CourceTypeID = CT.CourceTypeID
where recipeID = @recipeID;

GO
