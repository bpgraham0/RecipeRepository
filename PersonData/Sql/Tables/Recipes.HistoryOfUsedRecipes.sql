IF OBJECT_ID(N'Recipes.HistoryOfUsedRecipes') IS NULL
BEGIN

create table Recipes.HistoryOfUsedRecipes
(
	RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes.Recipe(RecipeId) PRIMARY KEY,
	LastDateUsed DateTime2 NOT NULL,
	Stars INT NOT NULL check (Stars>=0 and Stars <=5 )

      CONSTRAINT [PK_Recipes_HistoryOfUsedRecipes_RecipeId] PRIMARY KEY NONCLUSTERED
      (
         RecipeId
         
      )
         
      CONSTRAINT FK_Recipes_HistoryOfUsedRecipes_Recipes_Recipe FOREIGN KEY(RecipeID)
      REFERENCES Recipe.Recipe(RecipeId),

      CONSTRAINT [PK_Recipes_HistoryOfUsedRecipes_Stars] 
      (
         Stars
         
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
      WHERE kc.parent_object_id = OBJECT_ID(N'Recipes.HistoryOfUsedRecipes')
         AND kc.[name] = N'PK_Recipes_Ingredient_IngredientId_Name'
   )
BEGIN
   ALTER TABLE Recipe.HistoryOfUsedRecipes
   ADD CONSTRAINT [PK_Recipes_Ingredient_IngredientId_Name] PRIMARY KEY NONCLUSTERED
   (
         RecipeId

   )
END;


IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Recipes.HistoryOfUsedRecipes')
         AND fk.referenced_object_id = OBJECT_ID(N'Recipes.Recipe')
         AND fk.[name] = N'FK_Recipes_HistoryOfUsedRecipes_Recipes_Recipe'
   )
BEGIN
   ALTER TABLE Recipes.HistoryOfUsedRecipes
   ADD CONSTRAINT [FK_Recipes_HistoryOfUsedRecipes_Recipes_Recipes] FOREIGN KEY
   (
      RecipeId
   )
   REFERENCES Recipes.Recipe
   (
     RecipeId
   );
END;



