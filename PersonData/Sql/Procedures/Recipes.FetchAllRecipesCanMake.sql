CREATE OR ALTER PROCEDURE Recipes.FetchAllRecipesCanMake
As
select R.[Name]
from Recipes.ingredient I
Inner Join Recipes.IngredientList IL ON I.ingredientID=IL.ingredientID
and I.HaveItem='true'
Inner Join recipe.IL





GO
