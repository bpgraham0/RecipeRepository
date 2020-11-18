CREATE OR ALTER PROCEDURE Recipes.CreateIngredient
	@Name INT,
	@HaveItem TinyINT
AS

INSERT Recipes.Ingredient(Name, HaveItem)
select @Name,@HaveItem
WHERE   NOT EXISTS 
	(select 1
	from Recipes.Ingredient
	where Name=@Name
	);
GO
