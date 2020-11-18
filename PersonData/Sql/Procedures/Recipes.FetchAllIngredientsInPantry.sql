CREATE OR ALTER PROCEDURE Recipes.FetchAllIngredientsInPantry
AS

select I.Name
from Recipes.ingredient I
where I.HaveItem='True';

GO
