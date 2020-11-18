
CREATE OR ALTER PROCEDURE Recipes.CreateUpdateFoodType
	@Name  NVARCHAR(64),
	@FoodTypeID INT OUTPUT

AS



if EXISTS 
	(select *
	from Recipes.FoodType
	where [Name]=@Name
	)
begin
Select @FoodTypeID=FT.FoodTypeID
from Recipes.FoodType FT
where [Name]=@Name
end
else 
begin
INSERT Recipes.FoodTypeID([Name])
SELECT  @Name
SET @FoodTypeID = SCOPE_IDENTITY();
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