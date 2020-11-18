
CREATE OR ALTER PROCEDURE Recipes.FetchAllRecipesCanMake
As
select R.[name],FT.[Name],CT.[name],R.Description,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
Inner Join (
select R.RecipeId
from Recipes.recipe R

EXCEPT

select IL.RecipeId as RecipeID
from Recipes.IngredientList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
) temp on temp.RecipeID =R.RecipeID
GO

