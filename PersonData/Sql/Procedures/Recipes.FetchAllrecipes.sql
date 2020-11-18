﻿CREATE OR ALTER PROCEDURE Recipes.FetchAllRecipes
AS

select R.[name],FT.[Name],CT.[name],R.Discription,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.RecipeID=R.RecipeID
Inner Join Recipes.CourseType CT on CT.RecipeID=R.RecipeID
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID


GO
