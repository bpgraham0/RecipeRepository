select *
from Recipes.Measurement

insert Recipes.Measurement([Name])
values 
(N'Cup'),   
(N'Tablespoon'),   
(N'Teaspoon'),   
(N'Fluid ounce'),   
(N'Ounce'),   
(N'Pound '), 
(N'Shot'),  
(N'Liter'),   
(N'Inch'), 
(N'Foot'), 
(N'Yard'), 
(N'Rod'), 
(N'League'), 
(N'Fathom'), 
(N'Square foot'), 
(N'Square inch'), 
(N'Cubic inch'), 
(N'Cubic foot'), 
(N'Minim'), 
(N'Jig'),
(N'Pint'),   
(N'Quart'),   
(N'Pottle'),   
(N'Gallon'),   
(N'Hogshead'),   
(N'Ton'),   
(N'Milliliter'),   
(N'Gram'),   
(N'Kilogram'),
(N'units');


declare @id int;
 exec Recipes.CreateIngredient N'sugar',0,@id;
 exec Recipes.CreateIngredient N'Cream Cheese',1,@id;
 exec Recipes.CreateIngredient N'Chicken Breast',1,@id;
 exec Recipes.CreateIngredient N'Flower',1,@id;
 exec Recipes.CreateIngredient N'Baking soda',0,@id;
 exec Recipes.CreateIngredient N'Egg',1,@id;
 exec Recipes.CreateIngredient N'Carrots',1,@id;
 exec Recipes.CreateIngredient N'Rasins',1,@id;
 exec Recipes.CreateIngredient N'Pecans',1,@id;
 exec Recipes.CreateIngredient N'Salt',0,@id;
 exec Recipes.CreateIngredient N'Cinnamon',1,@id;
 exec Recipes.CreateIngredient N'Vanilla',1,@id;
 exec Recipes.CreateIngredient N'Cooking Oil',1,@id;
 exec Recipes.CreateIngredient N'Cheese',1,@id;
 exec Recipes.CreateIngredient N'lettus',0,@id;
 exec Recipes.CreateIngredient  N'Bacon Bits',1,@id;
 exec Recipes.CreateIngredient N'Ranch',1,@id;
 exec Recipes.CreateIngredient N'Spinich',1,@id;

 exec Recipes.CreateIngredient N'Bread',1,@id;
 exec Recipes.CreateIngredient N'Mustard',0,@id;
 exec Recipes.CreateIngredient N'Tomato',1,@id;
 exec Recipes.CreateIngredient N'Mayo',1,@id;

 exec Recipes.CreateIngredient N'Gin',1,@id;
 exec Recipes.CreateIngredient N'Vermouth',1,@id;

 exec Recipes.CreateIngredient N'Rye Whiskey',1,@id;
 exec Recipes.CreateIngredient N'Egg White',1,@id;
 exec Recipes.CreateIngredient N'Red Vermouth',1,@id;
 exec Recipes.CreateIngredient N'Bitters',0,@id;
 exec Recipes.CreateIngredient N'Frozen pizza ',1,@id;
 exec Recipes.CreateIngredient N'Ramin',1,@id;
 

  exec Recipes.CreateUpdateSteps 7,1,N'spaghetti'
  exec Recipes.CreateUpdateSteps 7,2,N'Alfradlo Sause'








  exec Recipes.CreateUpdateFoodType N'Cake',@id;
  exec Recipes.CreateUpdateFoodType N'Salad',@id;
  exec Recipes.CreateUpdateFoodType N'Sandwitch',@id;
  exec Recipes.CreateUpdateFoodType N'Fried Food',@id;
  exec Recipes.CreateUpdateFoodType N'cocktail',@id;
  exec Recipes.CreateUpdateFoodType N'Frozen Food',@id;
  exec Recipes.CreateUpdateFoodType N'Chicken',@id;
  exec Recipes.CreateUpdateFoodType N'ramin',@id;
  exec Recipes.CreateUpdateFoodType N'pasta',@id;




  



  exec Recipes.CreateUpdateCourseType N'Desert', @id;
  exec Recipes.CreateUpdateCourseType N'appetizers', @id;
  exec Recipes.CreateUpdateCourseType N'Lunch', @id;
  exec Recipes.CreateUpdateCourseType N'Main Course', @id;
  exec Recipes.CreateUpdateCourseType N'Alcohol', @id;
  exec Recipes.CreateUpdateCourseType N'Dinner', @id;
  exec Recipes.CreateUpdateCourseType N'Soup', @id;
  exec Recipes.CreateUpdateCourseType N'entrie', @id;



  


  exec Recipes.CreateUpdateRecipe  1,1,  N'Carrot Cake', N'A sweet cake, Looks orange and taists like carrots', 8,20,45,@id;
  exec Recipes.CreateUpdateRecipe   2,2,  N'salad', N'A crunchy veggie dish', 2,15,0,@id;
  exec Recipes.CreateUpdateRecipe    3,3,  N'Ham Sandwitch', N'meat between bread', 1,10,0,@id;
  exec Recipes.CreateUpdateRecipe    4,4,  N'Fried Chicken', N'yum yum', 3,35,35,@id;
  exec Recipes.CreateUpdateRecipe    5,5,  N'Martini', N'alcoholic drink, tis one of the most known cocktails in history', 3,35,35,@id;
  exec Recipes.CreateUpdateRecipe    5,5,  N'Manhattan', N'alcoholic drink,my favorite one!', 3,35,35,@id;
  exec Recipes.CreateUpdateRecipe    6,6,  N'Frozen Pizza', N'Quick ', 3,35,35,@id;

  exec Recipes.CreateUpdateRecipe    6,5,  N'Bacon Chicken', N'alcoholic drink,my favorite one!', 3,35,35,@id;
  exec Recipes.CreateUpdateRecipe    7,5,  N'Ramin', N'College Food', 3,35,35,@id;
  exec Recipes.CreateUpdateRecipe    8,8,  N'Spaghetti Alfrado', N'Tasty Pasta Dinner', 3,35,35,@id;



 
  --exec Recipes.CreateUpdateRecipe  1,1,  N'Carrot Cake', N'A sweet cake, Looks orange and taists like carrots', 8,20,45,@id;
  


  exec Recipes.AddToIngredientList 1,4, 1,2 
  exec Recipes.AddToIngredientList  1,5, 2,2
  exec Recipes.AddToIngredientList   1,10, 2,.5
  exec Recipes.AddToIngredientList  1,11, 2,1.5
  exec Recipes.AddToIngredientList  1,13, 1,1.25
  exec Recipes.AddToIngredientList  1,1, 1,1
  exec Recipes.AddToIngredientList  1,6, 1,1
  exec Recipes.AddToIngredientList  1,6, 30,4

  exec Recipes.AddToIngredientList   2,15, 30,4
  exec Recipes.AddToIngredientList  2,16, 30,4
  exec Recipes.AddToIngredientList  2,17, 30,4
  exec Recipes.AddToIngredientList  2,18, 30,4

  exec Recipes.AddToIngredientList  3,19, 30,2
  exec Recipes.AddToIngredientList  3,20, 2,2
  exec Recipes.AddToIngredientList  3,21, 30,1
  exec Recipes.AddToIngredientList  3,22, 2,1

   exec Recipes.AddToIngredientList  4,3, 5,7
  exec Recipes.AddToIngredientList   4,2, 1,3

     exec Recipes.AddToIngredientList 5,23, 2,1
  exec Recipes.AddToIngredientList   5,23, 2,1

  exec Recipes.AddToIngredientList   6,24, 2,1
  exec Recipes.AddToIngredientList   6,25, 2,1
  exec Recipes.AddToIngredientList   6,26, 2,1
  exec Recipes.AddToIngredientList   6,27, 2,1
  exec Recipes.AddToIngredientList   7,28, 2,1

  exec Recipes.AddToIngredientList   8,3, 2,8
  exec Recipes.AddToIngredientList   8,16, 1,2

    exec Recipes.AddToIngredientList   9,29, 30,2

    exec Recipes.AddToIngredientList   10,30, 1,4
    exec Recipes.AddToIngredientList   10,30, 2,10

  
  exec Recipes.CreateUpdateSteps 1,1,N'Dry Ingredients in bowl'
  exec Recipes.CreateUpdateSteps 1,2,N'wet Ingredients in bowl'
  exec Recipes.CreateUpdateSteps 1,3,N'add carrots  and rasins'
  exec Recipes.CreateUpdateSteps 1,4,N'bake at 350'
  exec Recipes.CreateUpdateSteps 1,5,N'ice the cake'

    exec Recipes.CreateUpdateSteps 2,1,N'cut lettus'
  exec Recipes.CreateUpdateSteps 2,2,N'add toppings'
  exec Recipes.CreateUpdateSteps 2,3,N'enjoy'

  exec Recipes.CreateUpdateSteps 3,1,N'slice bread'
  exec Recipes.CreateUpdateSteps 3,2,N'add to bread'
  exec Recipes.CreateUpdateSteps 3,3,N'enjoy'

  exec Recipes.CreateUpdateSteps 4,1,N'flower chicken'
  exec Recipes.CreateUpdateSteps 4,2,N'fry'

  exec Recipes.CreateUpdateSteps 5,1,N'Mix with Ice'

  exec Recipes.CreateUpdateSteps 5,2,N'Shake with Egg White'
  exec Recipes.CreateUpdateSteps 6,1,N'Mix with Ice'
  exec Recipes.CreateUpdateSteps 7,1,N'Heat'

  exec Recipes.CreateUpdateSteps 9,1,N'Dude, ist Ramain'
  exec Recipes.CreateUpdateSteps 10,1,N'cook spaghetti'
  exec Recipes.CreateUpdateSteps 10,2,N'heat alfrad'
  exec Recipes.CreateUpdateSteps 10,3,N'combine'



  insert into Recipes.HistoryOfUsedRecipes(RecipeId,LastDateUsed,Stars)
  values(2, DATEADD(Day,-60, GetDate()),3.2)