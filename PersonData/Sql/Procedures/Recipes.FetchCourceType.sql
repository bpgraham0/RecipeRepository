CREATE OR ALTER PROCEDURE Recipes.FetchCourceType
	@recipeID int ,
	@Name NVARCHAR(64) output
AS

select @Name=CT.Name
from Recipes.Recipe R
Inner Join  Recipes.CourseType CT ON R.CourseTypeId = CT.CourseTypeId
where recipeID = @recipeID;

GO