using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipeData.Repositories;



namespace RecipeRepositoryApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=RecipeRepository;Integrated Security=True";
            //string connectionString = @"Data Source=(localdb)\LocalDBApp1;Initial Catalog=RecipeRepository;Integrated Security=True";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RecipeRepositoryForm(new SqlRecipeRepository(connectionString), new SqlIngredientListRepository(connectionString), new SqlFoodTypeRepository(connectionString), new SqlCourseTypeRepository(connectionString)));
        }
    }
}
