--Drop ProcedureList
drop procedure if exists Recipes.AddToHistoryOfUsedRecipes,
						 Recipes.AddToIngredientList,
						 Recipes.CreateIngredient,
						 Recipes.CreateUpdateCourseType,
						 Recipes.CreateUpdateFoodType,
						 Recipes.CreateUpdateRecipe,
						 Recipes.CreateUpdateSteps,
						 Recipes.DeleteFromIngredientList,
						 Recipes.DeleteRecipe,
						 Recipes.DeleteStep,
						 Recipes.FetchAllIngredients,
						 Recipes.FetchAllIngredientsInPantry,
						 Recipes.FetchAllRecipes,
						 Recipes.FetchAllRecipesCanMake,
						 Recipes.FetchCookTime,
						 Recipes.FetchCourseType,
						 Recipes.FetchCourceType,
						 Recipes.FetchFoodType,
						 Recipes.FetchFullHistory,
						 Recipes.FetchHaveExceptX,
						 Recipes.FetchHistory,
						 Recipes.FetchIngredientList,
						 Recipes.FetchMeasurementId,
						 Recipes.FetchMeasurementList,
						 Recipes.FetchRecipeByName,
						 Recipes.FetchRemindRecipes,
						 Recipes.FetchStars,
						 Recipes.FetchSteps,
						 Recipes.FetchTopTen,
						 Recipes.SearchAllRecipes,
						 Recipes.UpdateHaveItem

go

--drop all tables
drop table if exists Recipes.HistoryOfUsedRecipes
drop table if exists Recipes.Steps
drop table if exists Recipes.IngredientList
drop table if exists Recipes.Measurement
drop table if exists Recipes.Ingredient
drop table if exists Recipes.Recipe
drop table if exists Recipes.CourseType
drop table if exists Recipes.FoodType
go

--drop schema
drop schema if exists Recipes
go

--create scheme
IF SCHEMA_ID(N'Recipes') IS NULL
   EXEC(N'CREATE SCHEMA [Recipes];');
GO
--create ingreadent table
create table Recipes.Ingredient
(
	IngredientId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
	Origin NVARCHAR(64), -- Take out Origin Property
	HaveItem BIT NOT NULL check (HaveItem = 1 or HaveItem = 0),
	CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
)

CREATE TABLE Recipes.Measurement
(
	MeasurementId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
)

CREATE TABLE Recipes.FoodType
(
	FoodTypeId INT NOT NULL identity(1,1) PRIMARY KEY, 
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
)

CREATE TABLE Recipes.CourseType
(
	CourseTypeId INT NOT NULL identity(1,1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
)

CREATE TABLE Recipes.Recipe
(
	RecipeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,	
	FoodTypeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.FoodType(FoodTypeId),
	CourseTypeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.CourseType(CourseTypeId),
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
	[Description] NVARCHAR(1024) NOT NULL,
	ServingSize Float(53) NOT NULL,
	PrepTime INT NOT NULL,
	CookTime INT NOT NULL,
	CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
)


Create Table Recipes.IngredientList
(
	RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Recipe(RecipeId),
	IngredientId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Ingredient(IngredientId),
	MeasurementId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Measurement(MeasurementId),
	Quantity Float(53) NOT NULL,

	Constraint PK_Recipe_IngredientList_RecipeId_IngredientId primary key(RecipeId, IngredientId)

)

Create Table Recipes.Steps
(
	StepId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Recipe(RecipeId),
	StepNumber INT NOT NULL,
	StepDescription NVARCHAR(1024) NOT NULL
)

CREATE TABLE Recipes.HistoryOfUsedRecipes
(
	RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Recipe(RecipeId),
	LastDateUsed DateTime2 NOT NULL,
	Stars Float(53) NOT NULL,

	CONSTRAINT PK_Recipes_HistoryOfUsedRecipes_RecipeId_LastDateUsed PRIMARY KEY(RecipeId,LastDateUsed),
	CONSTRAINT C_Recipes_HistoryOfUsedRecipes_Stars Check (Stars>=0 and Stars <=5 )

)

go


/*
insert Recipes.FoodType([Name]) values (N'Fruit'),('Vegitables');
insert Recipes.CourseType([Name]) values (N'Breakfast'),(N'Lunch');


insert Recipes.Recipe(FoodTypeId,CourseTypeId,[Name], [Description], ServingSize, PrepTime, CookTime)
values 
((select FoodTypeId from Recipes.FoodType where [Name] = N'Fruit'),(select CourseTypeId from Recipes.CourseType where [Name] = N'Breakfast'), N'Soup', N'Delicious Soup', 3, 30, 15),
((select FoodTypeId from Recipes.FoodType where [Name] = N'Vegitables'),(select CourseTypeId from Recipes.CourseType where [Name] = N'Lunch'), N'Chicken', N'Delicious Chicken', 3, 30, 15)

exec Recipes.AddToHistoryOfUsedRecipes @RecipeId = 1, @Stars = 0
exec Recipes.AddToHistoryOfUsedRecipes @RecipeId = 2, @Stars = 0 
exec Recipes.AddToIngredientList @RecipeId =1, @IngredientId = 1, @MeasurementId = 17, @Quantity = 2
go
*/
--Select *
--from Recipes.Ingredient
--Select * 
--from Recipes.Measurement
--Select * 
--from Recipes.IngredientList
--Select * 
--from Recipes.Recipe
/*




select R.RecipeId, R.[name],FT.[Name],CT.[name],R.[Description],R.CookTime,R.PrepTime,R.ServingSize,Hr.Stars
from Recipes.Recipe R
Inner Join Recipes.FoodType FT on FT.FoodTypeId=R.FoodTypeId
Inner Join Recipes.CourseType CT on CT.CourseTypeId=R.CourseTypeId
Inner join Recipes.IngredientList IL on IL.RecipeId = R.RecipeId 
left Join Recipes.HistoryOfusedRecipes HR on HR.RecipeID=R.RecipeID
*/
