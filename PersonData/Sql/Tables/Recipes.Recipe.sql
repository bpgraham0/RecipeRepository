IF OBJECT_ID(N'Recipes.Recipe') IS NULL
BEGIN
   CREATE TABLE Recipes.Recipe
   (
    RecipeId INT NOT NULL IDENTITY(1, 1) ,
	FoodTypeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.FoodType(FoodTypeId),
	CourseTypeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.CourseType(CourseTypeId),
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
	[Description] NVARCHAR(1024) NOT NULL,
	ServingSize INT NOT NULL,
	PrepTime INT NOT NULL,
	CookTime INT NOT NULL,
	CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())

      CONSTRAINT [PK_Recipes_Recipe_RecipeId_Name] PRIMARY KEY CLUSTERED
      (
         RecipeId ASC,
         [Name]
      )

      CONSTRAINT FK_Recipes_Recipe_Recipes_FoodType FOREIGN KEY(FoodTypeId)
      REFERENCES Recipe.FoodTypeId(FoodTypeId),

      CONSTRAINT FK_Recipes_Recipe_Recipes_CourseType FOREIGN KEY(CourseTypeId)
      REFERENCES Recipe.CourseType(CourseTypeId)
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipe.Recipe')
         AND kc.[name] = N'PK_Recipes_Recipe_RecipeId'
   )
BEGIN
   ALTER TABLE Recipe.Recipe
   ADD CONSTRAINT [PK_Recipes_Recipe_RecipeId_Name] UNIQUE CLUSTERED
   (
      RecipeId ASC,
      [Name]
   )
END;



IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.Recipe')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.CourseType')
         AND fk.[name] = N'FK_Recipes_Recipe_Recipes_CourseType'
   )
BEGIN
   ALTER TABLE Recipes.Recipe
   ADD CONSTRAINT [FK_Recipes_Recipe_Recipes_CourseType] FOREIGN KEY
   (
      CourseTypeId
   )
   REFERENCES Recipes.FoodType
   (
      CourseTypeId
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.Recipe')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.FoodType')
         AND fk.[name] = N'FK_Recipes_Recipe_Recipes_FoodType'
   )
BEGIN
   ALTER TABLE Recipes.Recipe
   ADD CONSTRAINT [FK_Recipes_Recipe_Recipes_FoodType] FOREIGN KEY
   (
      FoodTypeId
   )
   REFERENCES Recipes.FoodType
   (
      FoodTypeId
   );
END;

/****************************
 * Check Constraints
 ****************************/

--IF NOT EXISTS
--   (
--      SELECT *
--      FROM sys.check_constraints cc
--      WHERE cc.parent_object_id = OBJECT_ID(N'Recipe.Recipe')
--         AND cc.[name] = N'PK_Recipe_Recipe_RecipeId'
--   )
--BEGIN
--   ALTER TABLE Recipe.Recipe
--   ADD CONSTRAINT [PK_Recipe_Recipe_RecipeId] CHECK
--   (
--      FirstName > N'' OR LastName > N''
--   )
--END;
