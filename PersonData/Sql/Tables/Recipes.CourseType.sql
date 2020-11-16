IF OBJECT_ID(N'Recipes.CourseType') IS NULL
BEGIN

CREATE TABLE Recipes.CourseType
(
	CourseTypeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
	TimeOfDay NVARCHAR(64)

      CONSTRAINT [PK_Recipes_CourseType_CourseTypeId_Name] PRIMARY KEY NONCLUSTERED
      (
         CourseTypeId ASC,[Name]
         
      )
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipes.CourseType')
         AND kc.[name] = N'PK_Recipes_CourseType_CourseTypeId_Name'
   )
BEGIN
   ALTER TABLE Recipe.FoodType
   ADD CONSTRAINT [PK_Recipes_CourseType_CourseTypeId_Name] UNIQUE NONCLUSTERED
   (
         CourseTypeId ASC,[Name]

   )
END;




