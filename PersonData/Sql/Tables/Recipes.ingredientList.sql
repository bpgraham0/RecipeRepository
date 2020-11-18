IF OBJECT_ID(N'Recipes.IngredientList') IS NULL
BEGIN
Create Table Recipes.IngredientList
(
	RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Recipe(RecipeId) PRIMARY KEY,
	IngredientId  INT NOT NULL FOREIGN KEY REFERENCES Recipes.Ingredient(IngredientId),
	MeasurementId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Measurements(MeasurementId),--what
	Quantity Float(53) NOT NULL

      CONSTRAINT [PK_Recipes_IngredientList_RecipeId_IngredientId] PRIMARY KEY CLUSTERED
      (
         RecipeId,IngredientId
         
      )

      CONSTRAINT FK_Recipes_IngredientList_Recipes_Recipe FOREIGN KEY(RecipeId)
      REFERENCES Recipe.Recipe(RecipeId),
      
      CONSTRAINT FK_Recipes_IngredientList_Recipes_Ingredient FOREIGN KEY(IngredientId)
      REFERENCES Recipe.Ingredient(IngredientId),
      
      CONSTRAINT FK_Recipes_IngredientList_Recipes_Measurement FOREIGN KEY(MeasurementId)
      REFERENCES Recipe.Measurement(MeasurementId)
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipe.Steps')
         AND kc.[name] = N'PK_Recipes_IngredientList_RecipeId_IngredientId'
   )
BEGIN
   ALTER TABLE Recipe.Recipe
   ADD CONSTRAINT [PK_Recipes_IngredientList_RecipeId_IngredientId] UNIQUE CLUSTERED
   (
      RecipeId ,IngredientId

   )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.IngredientList')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.Recipe')
         AND fk.[name] = N'FK_Recipes_IngredientList_Recipes_Recipe'
   )
BEGIN
   ALTER TABLE Recipes.IngredientList
   ADD CONSTRAINT [FK_Recipes_IngredientList_Recipes_Recipes] FOREIGN KEY
   (
      RecipeId
   )
   REFERENCES Recipes.Recipe
   (
     RecipeId
   );
END;


IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.IngredientList')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.Ingredient')
         AND fk.[name] = N'FK_Recipes_IngredientList_Recipes_Ingredient'
   )
BEGIN
   ALTER TABLE Recipes.IngredientList
   ADD CONSTRAINT [FK_Recipes_IngredientList_Recipes_Ingredient] FOREIGN KEY
   (
      IngredientId
   )
   REFERENCES Recipes.Ingredient
   (
     IngredientId
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.IngredientList')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.Measurement')
         AND fk.[name] = N'FK_Recipes_IngredientList_Recipes_Measurement'
   )
BEGIN
   ALTER TABLE Recipes.IngredientList
   ADD CONSTRAINT [FK_Recipes_IngredientList_Recipes_Measurement] FOREIGN KEY
   (
      MeasurementId
   )
   REFERENCES Recipes.Measurement
   (
     MeasurementId
   );
END;


