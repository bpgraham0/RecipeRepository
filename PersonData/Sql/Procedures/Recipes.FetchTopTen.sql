
CREATE OR ALTER PROCEDURE Recipes.FetchTopTen
AS
select TOP (10) R.[name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars

from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Inner Join Recipes.HistoryOfUsedRecipes HR on R.RecipeID=Hr.RecipeID
inner Join(
Select R.RecipeID as RecipeID
from Recipes.Recipe R

EXCEPT

select IL.RecipeId as RecipeID
from Recipes.IngredientList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
) temp on temp.RecipeID =HR.RecipeID

where HR.LastDateUsed BETWEEN DATEADD(DAY,-30,SYSDATETIMEOFFSET()) and (SYSDATETIMEOFFSET())
order By HR.Stars

GO
