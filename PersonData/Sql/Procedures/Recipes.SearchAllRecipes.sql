
CREATE OR ALTER PROCEDURE Recipes.SearchAllRecipes
	@Name VARCHAR(MAX),
	@Description VARCHAR(MAX),
	@CourseType VARCHAR(MAX),
	@FoodType VARCHAR(MAX),
	@StarsMin float(53),
	@StarsMax float(53),
	@Ingreadent VARCHAR(MAX),
	@PreptimeMax int,
	@cooktimeMax int,
	@DateMin date  ,
	@DateMax Date,
	@Have Bit,
	@DateChanged bit

AS

IF (@DateChanged = 0)
begin
SET @DateMin = DATEADD(YEAR, -100, getdate())
SET @DateMax = getdate()
end




select R.[name] as name  ,FT.[Name] as "Food Type",CT.[name]As "Course Type",R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Left Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Left Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Left Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
Inner Join (
select IL.RecipeId
from Recipes.IngredientList IL
Inner Join Recipes.Ingredient I On I.IngredientId = IL.IngredientId
where I.[Name] Like '%'+ @Ingreadent+'%'
and(
I.HaveItem =1
or I.HaveItem=@Have)

intersect

select R.recipeID  As recipeID
from Recipes.Recipe R
where R.[Name] Like '%'+ @Name+'%'
and PrepTime <=@PreptimeMax
and CookTime<=@cooktimeMax

intersect
select R.recipeID  As recipeID
from Recipes.Recipe R
where R.[Name] Like '%'+ @Description+'%'
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
) temp on Temp.RecipeId= R.recipeID;

GO