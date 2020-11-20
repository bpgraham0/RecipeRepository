
CREATE OR ALTER PROCEDURE Recipes.FetchCourseType
	@RecipeId int ,
	@Name NVARCHAR(64) output
AS


select @Name=CT.Name 
from Recipes.Recipe R
Inner Join  Recipes.CourseType CT ON R.CourseTypeId = CT.CourseTypeId
where R.RecipeId = @RecipeId;

GO
