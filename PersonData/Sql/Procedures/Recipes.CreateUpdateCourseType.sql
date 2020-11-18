
CREATE OR ALTER PROCEDURE Recipes.CreateUpdateCourseType
	@Name  NVARCHAR(64),
	@CourseTypeID INT OUTPUT

AS



if EXISTS 
	(select *
	from Recipes.CourseType
	where [Name]=@Name
	)
begin
Select @CourseTypeID=FT.CourseTypeID
from Recipes.CourseType FT
where [Name]=@Name
end
else 
begin
INSERT Recipes.CourseTypeID([Name])
SELECT  @Name
SET @CourseTypeID = SCOPE_IDENTITY();
end

GO


--INSERT Recipes.Recipe([Name], [Description], ServingSize, PrepTime, CookTime, CourseTypeId, CourseTypeId)
--SELECT  @Name,@Description,@ServingSize,@PrepTime,@CookTime,@CourseTypeId,@CourseTypeId
--WHERE   NOT EXISTS 
--	(select 1
--	from Recipes.Recipe
--	where [Name]=@Name
--	);
--SET @RecipeId = SCOPE_IDENTITY();
--GO

--	UPDATE Recipes.Recipe
--	set [Name]= @[Name],
--		[Description] = @[Description],
--		ServingSize=@ServingSize,
--		PrepTime=@PrepTime,
--		CookTime=@CookTime,
--		CourseTypeId=@CourseTypeId,
--		CourseTypeI=@CourseTypeId
--	where RecipeID = @RecipeID