

-- adds one ingreadentrecipe combo to the ingreadient table
CREATE OR ALTER PROCEDURE  Recipes.AddToIngredientList
	@RecipeID INT,
	@IngredientID INT,
	@MeasurementID INT,
	@Quantity INT
AS

INSERT Recipes.ingredientList(RecipeId,IngredientId,MeasurementId,Quantity)
SELECT  @RecipeID,@IngredientID,@MeasurementID,@Quantity
WHERE   NOT EXISTS 
	(select 1
	from Recipes.ingredientList I
	where RecipeID=@RecipeID
	And IngredientID=@IngredientID
	);
GO
--adds a recipie  to the gistory with a ised on date and raiting if it is already added it updates those two feilds
CREATE OR ALTER PROCEDURE Recipes.AddToHistoryOfUsedRecipes
	@RecipeId INT,
	@Stars Float(53)
AS
if EXISTS 
	(select *
	from Recipes.HistoryOfUsedRecipes
	where RecipeID=@RecipeID
	)
begin
Update Recipes.HistoryOfUsedRecipes
set 
	Stars = @Stars,
	LastDateUsed = GETDATE()
where  RecipeID=@RecipeID;
end
else 
begin
INSERT Recipes.HistoryOfUsedRecipes(RecipeId, LastDateUsed,Stars)
VALUES (@RecipeId,GETDATE(),@Stars)
end
GO

--featches all recipes in the current table
CREATE OR ALTER PROCEDURE Recipes.FetchAllRecipes
AS

select R.[name] as "Recipe Name",FT.[name]as "Food Type",CT.[name] as "Course Type",R.[Description],R.CookTime as "Cook Time",R.PrepTime as "Preparation Time",R.ServingSize as "Serving Size"
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
GO
--updates the ingreadent for have Item for a spisific itemId
CREATE OR ALTER PROCEDURE Recipes.UpdateHaveItem
	@Name NVarChar(64),
	@HaveItem BIT
AS
Update Recipes.Ingredient
set HaveItem=@HaveItem,
	UpdatedOn=SYSDATETIMEOFFSET()
where name = @Name;
GO

--searches all recipes in the recipe tale with many feilds inputed if feilds are left empty it ignores those searches

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
	@DateChanged bit

AS

IF (@DateChanged = 0)
begin
SET @DateMin = DATEADD(YEAR, -100, getdate())
 set @DateMax  = DATEADD(day, 1 ,sysdatetimeoffset())
end

IF(@PreptimeMax = 0) begin 
set @PreptimeMax = 1000
end
IF(@cooktimeMax = 0) begin 
set @cooktimeMax = 1000
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
select R.recipeID  As recipeIDw
from Recipes.Recipe R
inner join Recipes.CourseType CT on CT.CourseTypeID = R.CourseTypeID
where CT.[Name] Like '%'+ @CourseType+'%'
intersect

(select R.RecipeId
from Recipes.Recipe R
except 
select R.recipeID As recipeID
from Recipes.Recipe R
right join Recipes.HistoryOfUsedRecipes HR on HR.recipeID = R.recipeID
where (HR.Stars < @StarsMin) or( Hr.Stars> @StarsMax) or
((HR.LastDateUsed  < @DateMin) or (Hr.LastDateUsed > @DateMax))
)
) temp on Temp.RecipeId= R.recipeID;
GO
/*
exec Recipes.SearchAllRecipes @Name = N'', @Description =N'', @CourseType = N'', @FoodType = N'', @StarsMin = 0, @StarsMax = 5,
@Ingreadent = N'', @PreptimeMax = 0, @cooktimeMax = 0, @DateMin = '2020-10-19', @DateMax = '2020-11-20', @DateChanged = 1
Go
*/


--fetch all recipes for a recipe with that same Id and gets all the steps with that recipe
CREATE OR ALTER PROCEDURE Recipes.FetchSteps
	@recipeID int
AS

select S.StepNumber as "Step Number",S.StepDescription
from Recipes.Steps S
where recipeID = @recipeID;

GO


--gets the stars for a current recipeId
CREATE OR ALTER PROCEDURE Recipes.FetchStars
	@RecipeId INT,
	@stars float output
AS
select @stars=HR.Stars
	from Recipes.HistoryOfUsedRecipes HR
	where HR.RecipeID=@RecipeID
go

-- one of our main 4 report queries this one  returns all recipes that you havent made in 30 days and is ordered by stars so that you can find new (old) things
CREATE OR ALTER PROCEDURE Recipes.FetchRemindRecipes
AS

select R.[name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Inner Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
and 30<DATEDIFF(DAY,Hr.LastDateUsed,SYSDATETIMEOFFSET())
order by Hr.Stars desc

GO
-- gets all the important things from a recipe name  
CREATE OR ALTER PROCEDURE Recipes.FetchRecipeByName
@Name NVARCHAR(64)
AS

select R.RecipeId ,FT.FoodTypeId,CT.CourseTypeId,
R.Description,R.ServingSize,R.CookTime,R.PrepTime
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
where R.[Name]=@Name;

GO

--fetch the measurment Id from the name
CREATE OR ALTER PROCEDURE Recipes.FetchMeasurementId
@Name NVARCHAR(64),
@MeasurementId  int output
AS

select @MeasurementId=M.MeasurementId
from Recipes.Measurement M
where M.[Name]=@Name;
GO

--gets all the measurment names 
CREATE OR ALTER PROCEDURE Recipes.FetchMeasurementList
AS

select MeasurementId,[Name]
from Recipes.Measurement M

GO


--fetch all ingreadents used for a spsific recipeid
CREATE OR ALTER PROCEDURE Recipes.FetchIngredientList
	@recipeID int
AS

select I.IngredientId, I.name as "Ingredient Name", IL.Quantity, M.name as "Measurement Name", I.HaveItem as "Item in Pantry"
from Recipes.IngredientList IL
Inner Join Recipes.Ingredient I ON  I.IngredientId = IL.IngredientId
Inner Join Recipes.Measurement M ON  M.MeasurementID = IL.MeasurementID
where recipeID = @recipeID;

GO
--feaches the history for a recipe
CREATE OR ALTER PROCEDURE Recipes.FetchHistory
	@recipeID int
AS

select R.name as "Recipe Name", HR.Stars,Hr.LastDateUsed
from Recipes.HistoryOfUsedRecipes HR
Inner Join Recipes.Recipe R On R.RecipeID = HR.RecipeID
where R.recipeID = @recipeID;

GO

--gets all of the recipes made and rated 
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
order By HR.Stars desc

GO

-- get all of the recipes that have all the ingredients except for x number of them, 0 for what you can make right now.  This is also one of our 4 main report qieries
CREATE OR ALTER PROCEDURE Recipes.FetchHaveExceptX
 @x int
 as
select R.[name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,count(iif(I.HaveItem = 0, 1, NULL)) As Need
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
left Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
inner Join Recipes.IngredientList IL on IL.RecipeID =R.RecipeID
inner join Recipes.Ingredient I on IL.IngredientID = I.IngredientID
group by R.[Name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
having count(iif(I.HaveItem = 0, 1, NULL))<=@x
order by Need

GO

--gets the course name from the Id
CREATE OR ALTER PROCEDURE Recipes.FetchCourseType
	@RecipeId int ,
	@Name NVARCHAR(64) output
AS


select @Name=CT.Name 
from Recipes.Recipe R
Inner Join  Recipes.CourseType CT ON R.CourseTypeId = CT.CourseTypeId
where R.RecipeId = @RecipeId;

GO



go

--Gets the full history table  
CREATE OR ALTER PROCEDURE Recipes.FetchFullHistory
AS

select R.name, HR.Stars,Hr.LastDateUsed
from Recipes.HistoryOfUsedRecipes HR
Inner Join Recipes.Recipe R On R.RecipeID = HR.RecipeID

GO


--gets the food type name from the Id
CREATE OR ALTER PROCEDURE Recipes.FetchFoodType
	@RecipeID int,
	@Name NVARCHAR(64) output
AS

select @Name=FT.Name
from Recipes.Recipe R
Inner Join  Recipes.FoodType FT ON R.FoodTypeID = FT.FoodTypeID
where recipeID = @RecipeID;

GO


--gets cook time from recipe ID
CREATE OR ALTER PROCEDURE Recipes.FetchCookTime
	@recipeID int
AS

select CookTime
from Recipes.recipe
where recipeID = @recipeID;

GO

--not used, gets all recies you can make with ingreadents in your pantrie
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

--gets all ingreadent that you have 
CREATE OR ALTER PROCEDURE Recipes.FetchAllIngredientsInPantry
AS

select I.Name
from Recipes.ingredient I
where I.HaveItem='True';

GO
--gets all the ingreadent names
CREATE OR ALTER PROCEDURE Recipes.FetchAllIngredients
AS

select I.Name, I.HaveItem
from Recipes.ingredient I

GO

--delets a recipe step with an id and number
CREATE OR ALTER PROCEDURE  Recipes.DeleteStep
	@RecipeID INT,
	@StepNumber INT

AS
delete From Recipes.Steps  
Where recipeID=@RecipeID
and StepNumber=@StepNumber ;

GO
/*
insert Recipes.Recipe(FoodTypeId,CourseTypeId,[Name], [Description], ServingSize, PrepTime, CookTime)
values 
((select FoodTypeId from Recipes.FoodType where [Name] = N'Fruit'),(select CourseTypeId from Recipes.CourseType where [Name] = N'Breakfast'), N'Soup', N'Delicious Soup', 3, 30, 15),
((select FoodTypeId from Recipes.FoodType where [Name] = N'Vegitables'),(select CourseTypeId from Recipes.CourseType where [Name] = N'Lunch'), N'Chicken', N'Delicious Chicken', 3, 30, 15)

select *
from Recipes.Recipe

*/

go
--delets the recipe from the Id and all assoited data
CREATE OR ALTER PROCEDURE Recipes.DeleteRecipe
	@RecipeId INt 
AS	
	DELETE FROM Recipes.IngredientList
		WHERE RecipeId in 
			(SELECT I.RecipeId
			from Recipes.IngredientList I
			WHERE I.RecipeID=@RecipeId);
	DELETE FROM Recipes.Steps
		WHERE RecipeId in 
			(SELECT s.RecipeId
			from Recipes.Steps s
			WHERE s.RecipeID=@RecipeId);

	DELETE FROM Recipes.HistoryOfUsedRecipes
		WHERE RecipeId in 
			(SELECT h.RecipeId
			from Recipes.HistoryOfUsedRecipes h
			WHERE h.RecipeID=@RecipeId);
	DELETE FROM Recipes.Recipe 
		WHERE RecipeId in 
			(SELECT r.RecipeId
			from Recipes.Recipe r
			WHERE r.RecipeID=@RecipeId);
GO


---delets an ingreadent from an ingreadent list with a recipe to delete it from
CREATE OR ALTER PROCEDURE  Recipes.DeleteFromIngredientList
	@RecipeID INT,
	@IngredientID INT

as
delete From Recipes.ingredientList  
Where recipeID=@RecipeID
and IngredientID=@IngredientID ;

GO

--craets a step with a discription and number and recipe id
CREATE OR ALTER PROCEDURE  Recipes.CreateUpdateSteps
	--StepId INT,
	@RecipeId INT,
	@StepNumber INT,
	@StepDescription NVARCHAR(1024)
	--@StepId INt Output
AS
if EXISTS 
	(select *
	from Recipes.Steps
	where RecipeId=@RecipeId
	and StepNumber=@StepNumber
	)
begin
UPDATE Recipes.Steps
	set StepDescription=@StepDescription
	where RecipeId=@RecipeId
	and StepNumber=@StepNumber
	SET @RecipeId = SCOPE_IDENTITY();
end
else 
begin
INSERT Recipes.Steps(RecipeId,StepNumber,StepDescription)
SELECT  @RecipeId,@StepNumber,@StepDescription
--SET @StepId = SCOPE_IDENTITY();
end

GO

--creates or alters a recipie, in the recipe table
CREATE OR ALTER PROCEDURE Recipes.CreateUpdateRecipe
	@FoodTypeId INT,
	@CourseTypeId INT,
	@Name NVARCHAR (64),
	@Description NVARCHAR(1024),
	@ServingSize float(53),
	@PrepTime INT,
	@CookTime INT,
	@RecipeId INt Output
AS
if EXISTS 
	(select *
	from Recipes.Recipe
	where [Name]=@Name
	)
begin
UPDATE Recipes.Recipe
	set [Name]= @Name,
		[Description] = @Description,
		ServingSize=@ServingSize,
		PrepTime=@PrepTime,
		CookTime=@CookTime,
		CourseTypeId=@CourseTypeId,
		FoodTypeId=@FoodTypeId,
		UpdatedOn=SYSDATETIMEOFFSET()
	where [Name] = @Name
	SET @RecipeId = SCOPE_IDENTITY();
end
else 
begin
INSERT Recipes.Recipe([Name], [Description], ServingSize, PrepTime, CookTime, CourseTypeId, FoodTypeId)
SELECT  @Name,@Description,@ServingSize,@PrepTime,@CookTime,@CourseTypeId,@FoodTypeId
SET @RecipeId = SCOPE_IDENTITY();
end

GO

--creates a food tpye from a namename
CREATE OR ALTER PROCEDURE Recipes.CreateUpdateFoodType
	@Name  NVARCHAR(64),
	@FoodTypeID INT OUTPUT

AS
if EXISTS 
	(select *
	from Recipes.FoodType
	where [Name]=@Name
	)
begin
Select @FoodTypeID=FT.FoodTypeID
from Recipes.FoodType FT
where [Name]=@Name
end
else 
begin
INSERT Recipes.FoodType([Name])
SELECT  @Name
SET @FoodTypeID = SCOPE_IDENTITY();
end

GO

--- creates the course type from a name
CREATE OR ALTER PROCEDURE Recipes.CreateUpdateCourseType
	@Name  NVARCHAR(64),
	@CourseTypeID INT OUTPUT

AS
if EXISTS 
	(select *
	from Recipes.CourseType
	where [Name]=@Name
	)
begin
Select @CourseTypeID=FT.CourseTypeID
from Recipes.CourseType FT
where [Name]=@Name
end
else 
begin
INSERT Recipes.CourseType([Name])
SELECT  @Name
SET @CourseTypeID = SCOPE_IDENTITY();
end

GO
--creates a ingreadient from a name
CREATE OR ALTER PROCEDURE Recipes.CreateIngredient
	@Name NVarChar(64),
	@HaveItem Bit,
	@IngredientId int output
AS

if EXISTS 
	(select 1
	from Recipes.Ingredient
	where Name=@Name
	)
begin
Select @IngredientId=FT.IngredientId
from Recipes.Ingredient FT
where [Name]=@Name
end
else 
begin
INSERT Recipes.Ingredient([Name],HaveItem)
SELECT  @Name, @HaveItem
SET @IngredientId = SCOPE_IDENTITY();
end
GO
--adds the recipie to history with stars
CREATE OR ALTER PROCEDURE Recipes.AddToHistoryOfUsedRecipes
	@RecipeId INT,
	@Stars Float(53)
AS
if EXISTS 
	(select *
	from Recipes.HistoryOfUsedRecipes
	where RecipeID=@RecipeID
	)
begin
Update Recipes.HistoryOfUsedRecipes
set 
	Stars = @Stars,
	LastDateUsed = GETDATE()
where  RecipeID=@RecipeID;
end
else 
begin
INSERT Recipes.HistoryOfUsedRecipes(RecipeId, LastDateUsed,Stars)
VALUES (@RecipeId,GETDATE(),@Stars)
end
GO