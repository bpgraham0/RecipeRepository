IF OBJECT_ID(N'Recipes.Steps') IS NULL
BEGIN
Create Table Recipes.Steps
(
	StepId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Recipe(RecipeId),
	StepNumber INT NOT NULL,
	StepDescription NVARCHAR(1024) NOT NULL

      CONSTRAINT [PK_Recipes_Steps_RecipeId] PRIMARY KEY CLUSTERED
      (
         StepId ASC
         
      )

      CONSTRAINT FK_Recipes_Steps_Recipes_Recipe FOREIGN KEY(RecipeId)
      REFERENCES Recipe.Recipe(RecipeId)

   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipes.Steps')
         AND kc.[name] = N'PK_Recipes_Steps_StepId'
   )
BEGIN
   ALTER TABLE Recipe.Steps
   ADD CONSTRAINT [PK_Recipes_Steps_StepId] UNIQUE NONCLUSTERED
   (
      StepId ASC

   )
END;



IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.Steps')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.Recipe')
         AND fk.[name] = N'FK_Recipes_Steps_Recipes_Recipe'
   )
BEGIN
   ALTER TABLE Recipes.Steps
   ADD CONSTRAINT [FK_Recipes_Steps_Recipes_Recipes] FOREIGN KEY
   (
      RecipeId
   )
   REFERENCES Recipes.Recipe
   (
     RecipeId
   );
END;
