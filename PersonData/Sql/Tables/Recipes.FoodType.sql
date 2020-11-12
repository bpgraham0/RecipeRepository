IF OBJECT_ID(N'Recipe.FoodType') IS NULL
BEGIN
   CREATE TABLE Recipe.FoodType
   (
      FoodTypeId TINYINT NOT NULL,
      [Name] NVARCHAR(64) NOT NULL,

      CONSTRAINT PK_Recipe_FoodType_FoodTypeId PRIMARY KEY CLUSTERED
      (
         FoodTypeId ASC
      )
   );
END;



 -- Unique Constraints


IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipe.FoodType')
         AND kc.[Name] = N'UK_Recipe_FoodType_Name'
   )
BEGIN
   ALTER TABLE Recipe.FoodType
   ADD CONSTRAINT [UK_Recipe_FoodType_Name] UNIQUE NONCLUSTERED
   (
      [Name] ASC
   )
END;