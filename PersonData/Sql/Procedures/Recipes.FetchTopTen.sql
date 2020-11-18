CREATE OR ALTER PROCEDURE Recipes.FetchTopTen

AS

select TOP (10)HR.RecipieID as r
from Recipes.HistoryOfUsedRecipes HR
where HR.LastDateUsed BETWEEN DATEADD(DAY,-30,SYSDATETIMEOFFSET()) and (SYSDATETIMEOFFSET())

EXCEPT

select IL.RecipieID as r
from Recipes.IngreadentList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
order By HR.Stars

GO
