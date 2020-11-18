CREATE OR ALTER PROCEDURE Recipes.FetchRecipeByName
@Name NVARCHAR(64)
AS

select R.RecipeId ,FT.[Name] as FoodTypeId,CT.[name] as CourseTypeId,
R.Description,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
where R.[name]=@Name;

GO
