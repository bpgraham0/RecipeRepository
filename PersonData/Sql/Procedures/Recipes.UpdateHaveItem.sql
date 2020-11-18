CREATE OR ALTER PROCEDURE Recipes.UpdateHaveItem
	@Name INT,
	@HaveItem BIT,
	@UpdatedOn Date
AS

Update Recipes.Ingredient
set HaveItem=@HaveItem,
	UpdatedOn=@UpdatedOn
where name = @Name;

GO
