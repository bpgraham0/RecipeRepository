CREATE OR ALTER PROCEDURE Recipes.FetchTopTen

AS


select TOP (10) R.[name],FT.[Name],CT.[name],R.Discription,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars

from Recipes.HistoryOfUsedRecipes HR
Inner Join Recipes.FoodType FT on FT.RecipeID=HR.RecipeID
Inner Join Recipes.CourseType CT on CT.RecipeID=HR.RecipeID
Inner Join Recipes.Recipe R on R.RecipeID=Hr.RecipeID
inner Join(
Select R.RecipeID as RecipeID
from Recipes.Recipe R

EXCEPT

select IL.RecipieID as RecipeID
from Recipes.IngreadentList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
) temp on temp.RecipeID =HR.RecipeID

where HR.LastDateUsed BETWEEN DATEADD(DAY,-30,SYSDATETIMEOFFSET()) and (SYSDATETIMEOFFSET())
order By HR.Stars

GO
