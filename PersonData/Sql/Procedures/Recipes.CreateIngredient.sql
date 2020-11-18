CREATE OR ALTER PROCEDURE Recipes.CreateIngredient
	@Name NVarChar(64),
	@HaveItem Bit,
	@IngredientId int output
AS

INSERT Recipes.Ingredient(Name, HaveItem)
select @Name,@HaveItem
@IngredientId = SCOPE_IDENTITY()

WHERE   NOT EXISTS 
	(select 1
	from Recipes.Ingredient
	where Name=@Name
	);
GO
