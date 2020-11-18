CREATE OR ALTER PROCEDURE Recipes.SearchAllRecipes
	@Name VARCHAR(MAX)=null,
	@Discription VARCHAR(MAX)=null,
	@CourseType VARCHAR(MAX)=null,
	@FoodType VARCHAR(MAX)=null,
	@StarsMin float(53)=0,
	@StarsMax float(53)=5,
	@Ingreadent VARCHAR(MAX),
	@PreptimeMax int=10000,
	@cooktimeMax int=10000,
	@DateMin date = null,
	@DateMax DAte= null,
	@AnyRecipe Bit='True'

AS
IF @DateMax is null
SET @DateMax = getdate()
IF @DateMin is null
SET @DateMin = DATEADD(YEAR, -50, getdate())
select R.[name],FT.[Name],CT.[name],R.Discription,R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.RecipeID=R.RecipeID
Inner Join Recipes.CourseType CT on CT.RecipeID=R.RecipeID
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
Inner Join (
select IL.RecipieID
from Recipes.IngreadentList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.HaveItem ='False'
or I.HaveItem=@Have



intersect

select R.recipeID  As recipeID
from Recipes.Recipe R
where R.[Name] Like '%'+ @Name+'%'
and PrepTime <=@PreptimeMax
and CookTime<=@cooktimeMax
intersect
select R.recipeID  As recipeID
from Recipes.Recipe R
where R.[Name] Like '%'+ @Discription+'%'
intersect
select R.recipeID  As recipeID
from Recipes.Recipe R
inner join Recipes.FoodType FT on FT.FoodTypeID = R.FoodTypeID
where FT.[Name] Like '%'+ @FoodType+'%'
intersect
select R.recipeID  As recipeID
from Recipes.Recipe R
inner join Recipes.CourseType CT on CT.CourseTypeID = R.CourseTypeID
where CT.[Name] Like '%'+ @CourseType+'%'
intersect
select R.recipeID As recipeID
from Recipes.Recipe R
inner join Recipes.HistoryOfUsedRecipes HR on HR.recipeID = R.recipeID
where HR.Stars between @StarsMin and @StarsMax
and HR.LastDateUsed  BETWEEN @DateMin and @DateMax
) temp on Temp.recipeID= R.recipeID

GO
