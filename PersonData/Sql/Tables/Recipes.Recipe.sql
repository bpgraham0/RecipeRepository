IF OBJECT_ID(N'Recipe.Recipe') IS NULL
BEGIN
   CREATE TABLE Recipe.Recipe
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

      CONSTRAINT [PK_Recipe_Recipe_RecipeId] PRIMARY KEY CLUSTERED
      (
         RecipeId ASC
      )

      CONSTRAINT FK_Recipe_FoodType_FoodTypeId FOREIGN KEY(FoodTypeId)
      REFERENCES Recipe.FoodTypeId(FoodTypeId),

      CONSTRAINT FK_Recipe_RecipeAddress_Person_AddressType FOREIGN KEY(CourseTypeId)
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
         AND kc.[name] = N'UK_Recipe_Recipe_Email'
   )
BEGIN
   ALTER TABLE Recipe.Recipe
   ADD CONSTRAINT [UK_Recipe_Recipe_Email] UNIQUE NONCLUSTERED
   (
      Email ASC
   )
END;

/****************************
 * Check Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.check_constraints cc
      WHERE cc.parent_object_id = OBJECT_ID(N'Recipe.Recipe')
         AND cc.[name] = N'CK_Recipe_Recipe_LastName_FirstName'
   )
BEGIN
   ALTER TABLE Recipe.Recipe
   ADD CONSTRAINT [CK_Recipe_Recipe_LastName_FirstName] CHECK
   (
      FirstName > N'' OR LastName > N''
   )
END;
