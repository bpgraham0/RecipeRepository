﻿CREATE OR ALTER PROCEDURE Recipes.FetchAllRecipesCanMake
As
select R.[name],FT.[Name],CT.[name],R.Discription,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.RecipeID=R.RecipeID
Inner Join Recipes.CourseType CT on CT.RecipeID=R.RecipeID
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
Inner Join Recipes.on HR.RecipeID=R.RecipeID
Inner Join (
select *
from Recipes.recipe R

EXCEPT

select IL.RecipieID as RecipeID
from Recipes.IngreadentList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
) temp on temp.RecipeID =R.RecipeID







GO
