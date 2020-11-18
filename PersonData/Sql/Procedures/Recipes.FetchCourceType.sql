CREATE OR ALTER PROCEDURE Recipes.FetchCourceType
	@recipeID,
	@Name NVARCHAR(64) output
AS

select @Name=CT.Name
from Recipes.Recipe R
Inner Join  Recipes.CourceType CT ON R.CourceTypeID = CT.CourceTypeID
where recipeID = @recipeID;

GO
