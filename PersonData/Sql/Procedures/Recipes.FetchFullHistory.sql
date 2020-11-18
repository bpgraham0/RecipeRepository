﻿CREATE OR ALTER PROCEDURE Recipes.FetchFullHistory
AS

select R.name, HR.Stars,Hr.LastDateUsed
from Recipes.HistoryOfUsedRecipes HR
Inner Join Recipes.Recipe R On R.RecipeID = HR.RecipeID

GO
