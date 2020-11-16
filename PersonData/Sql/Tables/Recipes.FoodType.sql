IF OBJECT_ID(N'Recipes.FoodType') IS NULL
BEGIN

CREATE TABLE Recipes.FoodType
(
	FoodTypeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE

      CONSTRAINT [PK_Recipes_FoodType_FoodTypeId_Name] PRIMARY KEY NONCLUSTERED
      (
         FoodTypeId ASC,[Name]
         
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
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipes.FoodType')
         AND kc.[name] = N'PK_Recipes_FoodType_FoodTypeId_Name'
   )
BEGIN
   ALTER TABLE Recipe.FoodType
   ADD CONSTRAINT [PK_Recipes_FoodType_FoodTypeId_Name] UNIQUE NONCLUSTERED
   (
         FoodTypeId ASC,[Name]

   )
END;




