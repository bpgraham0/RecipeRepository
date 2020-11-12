DECLARE @FoodTypeStaging TABLE
(
   FoodTypeId TINYINT NOT NULL PRIMARY KEY,
   [Name] VARCHAR(64) NOT NULL UNIQUE
);

/***************************** Modify values here *****************************/

INSERT @FoodTypeStaging(FoodTypeId, [Name])
VALUES
   (1, 'Vegitable'),
   (2, 'Fruit'),
   (3, 'Meat'),
   (4, 'Seafood'),
   (5, 'Dairy'),
   (6, 'Grain');

/******************************************************************************/

MERGE Recipe.FoodType T
USING @FoodTypeStaging S ON S.FoodTypeId = T.FoodTypeId
WHEN MATCHED AND S.[Name] <> T.[Name] THEN
   UPDATE
   SET [Name] = S.[Name]
WHEN NOT MATCHED THEN
   INSERT(FoodTypeId, [Name])
   VALUES(S.FoodTypeId, S.[Name]);

