IF OBJECT_ID(N'Recipes.Measurement') IS NULL
BEGIN

create table Recipes.Measurement
(
	MeasurementId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE,

      CONSTRAINT [PK_Recipes_Measurement_MeasurementId_Name] PRIMARY KEY NONCLUSTERED
      (
         MeasurementId ASC,[Name]
         
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
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipes.Measurement')
         AND kc.[name] = N'PK_Recipes_Measurement_MeasurementId_Name'
   )
BEGIN
   ALTER TABLE Recipe.Measurement
   ADD CONSTRAINT [PK_Recipes_Measurement_MeasurementId_Name] UNIQUE NONCLUSTERED
   (
         MeasurementId ASC,[Name]

   )
END;

