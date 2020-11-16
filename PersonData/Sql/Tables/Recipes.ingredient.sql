IF OBJECT_ID(N'Recipes.Ingredient') IS NULL
BEGIN

create table Recipes.Ingredient
(
	IngredientId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL UNIQUE,
	HaveItem BIT NOT NULL DEFAULT('false'),
	CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())

      CONSTRAINT [PK_Recipes_Ingredient_IngredientId_Name] PRIMARY KEY NONCLUSTERED
      (
         IngredientId ASC,[Name]
         
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
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipes.Ingredient')
         AND kc.[name] = N'PK_Recipes_Ingredient_IngredientId_Name'
   )
BEGIN
   ALTER TABLE Recipe.Ingredient
   ADD CONSTRAINT [PK_Recipes_Ingredient_IngredientId_Name] UNIQUE NONCLUSTERED
   (
         IngredientId ASC,[Name]

   )
END;

