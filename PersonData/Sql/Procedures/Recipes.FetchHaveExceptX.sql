CREATE OR ALTER PROCEDURE Recipes.FetchHaveExceptX
 @x int
As
select R.[name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars,count(iif(I.HaveItem = 1 ,1,0)) As Need
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
inner Join Recipes.IngredientList IL on IL.RecipeID =R.RecipeID
inner join Recipes.Ingredient I on IL.IngredientID = I.IngredientID
group by R.[Name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
having count(iif(I.HaveItem = 1 ,1,0)) <=@x