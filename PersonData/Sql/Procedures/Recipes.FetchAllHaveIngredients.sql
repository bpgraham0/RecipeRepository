CREATE OR ALTER PROCEDURE Recipes.FetchAllHaveIngredients
AS

select I.Name
from Recipes.ingredient I
where I.HaveItem='True';

GO
