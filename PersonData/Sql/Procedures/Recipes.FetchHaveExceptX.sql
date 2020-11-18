CREATE OR ALTER PROCEDURE Recipes.FetchHaveExceptX
int @x
As
select R.[name],FT.[Name],CT.[name],R.Discription,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars,Count(I.HaveItem = 'false') As Need
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.RecipeID=R.RecipeID
Inner Join Recipes.CourseType CT on CT.RecipeID=R.RecipeID
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
inner Join Recipes.IngredientList IL on IL.RecipeID =R.RecipeID
inner join Recipes.Ingredient I on IL.IngredientID = I.IngredientID
where Need <=@x
group by R.RecipeID

