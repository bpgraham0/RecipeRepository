
CREATE OR ALTER PROCEDURE Recipes.CreateIngredient
	@Name NVarChar(64),
	@HaveItem Bit,
	@IngredientId int output
AS

INSERT Recipes.Ingredient(Name, HaveItem)
select @Name,@HaveItem
if EXISTS 
	(select 1
	from Recipes.Ingredient
	where Name=@Name
	)
begin
Select @IngredientId=FT.IngredientId
from Recipes.Ingredient FT
where [Name]=@Name
end
else 
begin
INSERT Recipes.Ingredient([Name],HaveItem)
SELECT  @Name, @HaveItem
SET @IngredientId = SCOPE_IDENTITY();
end
GO