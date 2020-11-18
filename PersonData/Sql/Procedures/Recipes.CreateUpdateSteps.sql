
CREATE OR ALTER PROCEDURE  Recipes.CreateUpdateSteps
	--StepId INT,
	@RecipeId INT,
	@StepNumber INT,
	@StepDescription NVARCHAR(1024),
	@StepId INt Output
AS



if EXISTS 
	(select *
	from Recipes.Steps
	where RecipeId=@RecipeId
	and StepNumber=@StepNumber
	)
begin
UPDATE Recipes.Steps
	set StepDescription=@StepDescription
	where RecipeId=@RecipeId
	and StepNumber=@StepNumber
	SET @RecipeId = SCOPE_IDENTITY();
end
else 
begin
INSERT Recipes.Steps(@RecipeId,@StepNumber,@StepDescription)
SELECT  @RecipeId,@StepNumber,@StepDescription
SET @StepId = SCOPE_IDENTITY();
end

GO
