
CREATE OR ALTER PROCEDURE Recipes.CreateUpdateRecipe
	@FoodTypeId INT,
	@CourseTypeId INT,
	@Name NVARCHAR (64),
	@Description NVARCHAR(1024),
	@ServingSize float(53),
	@PrepTime INT
	@CookTime INT,
	@RecipeId INt Output
AS



if EXISTS 
	(select *
	from Recipes.Recipe
	where [Name]=@Name
	)
begin
UPDATE Recipes.Recipe
	set [Name]= @Name,
		[Description] = @Description,
		ServingSize=@ServingSize,
		PrepTime=@PrepTime,
		CookTime=@CookTime,
		CourseTypeId=@CourseTypeId,
		FoodTypeId=@FoodTypeId
		UpdatedOn=SYSDATETIMEOFFSET()
	where [Name] = @Name
	SET @RecipeId = SCOPE_IDENTITY();
end
else 
begin
INSERT Recipes.Recipe([Name], [Description], ServingSize, PrepTime, CookTime, CourseTypeId, FoodTypeId)
SELECT  @Name,@Description,@ServingSize,@PrepTime,@CookTime,@CourseTypeId,@FoodTypeId
SET @RecipeId = SCOPE_IDENTITY();
end

GO


--INSERT Recipes.Recipe([Name], [Description], ServingSize, PrepTime, CookTime, CourseTypeId, FoodTypeId)
--SELECT  @Name,@Description,@ServingSize,@PrepTime,@CookTime,@CourseTypeId,@FoodTypeId
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
--		FoodTypeI=@FoodTypeId
--	where RecipeID = @RecipeID