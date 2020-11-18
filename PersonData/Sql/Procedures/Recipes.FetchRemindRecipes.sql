CREATE OR ALTER PROCEDURE Recipes.FetchRemindRecipes
AS

select Hr.recipeID
from Recipes.HistoryOfUsedRecipes Hr
--inner 
--where 

EXCEPT

select IL.RecipieID as r
from Recipes.IngreadentList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
order By HR.Stars

GO
