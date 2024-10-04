using Api.Core.Models;
using Api.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Data
{
    public static class ApplicationSeed
    {

        //get json directoru
        public async static Task SeedAsync(ApplicationContext context)
        {
            await SeedOperationOn<Brand>(context, "brands");
            await SeedOperationOn<ProductType>(context, "types");
            await SeedOperationOn<Product>(context, "products");
        }


        public async static Task SeedOperationOn<T>(ApplicationContext context , string fileName) where T : BaseModel
        {
            if(context.Set<T>().Count() == 0) 
            {
                var jsonFile = File.ReadAllText($@"..\Api.Data\DataSeeding\{fileName}.json");

                //convert from json to List<Brands>

                var listOfItems = JsonSerializer.Deserialize<List<T>>(jsonFile);


                if (listOfItems is not null)
                {
                    await context.Set<T>().AddRangeAsync(listOfItems);
                    //save changes
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
