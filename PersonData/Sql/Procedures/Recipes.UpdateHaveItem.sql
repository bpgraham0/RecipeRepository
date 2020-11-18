CREATE OR ALTER PROCEDURE Recipes.UpdateHaveItem
	@Name INT,
	@HaveItem BIT,
AS

Update Recipes.Ingredient
set HaveItem=@HaveItem,
	UpdatedOn=SYSDATETIMEOFFSET()
where name = @Name;

GO
