namespace JoladnijoBackendNet.Web.Entities
{
   public static class DataSeeder
   {
      public static void SeedWithDefault(ModelBuilder modelBuilder)
      {
         var assetCategories = new AssetCategory[]
         {
            new AssetCategory
            {
               Id = new Guid("121d25fc-35a5-43ed-9912-efd94a929575"),
               Name = "Gyerek",
               Icon = "child"
            },
            new AssetCategory
            {
               Id = new Guid("19cf880b-1d21-48d5-8d2e-9d33198f0b61"),
               Name = "Élelmiszer",
               Icon = "food"
            },
            new AssetCategory
            {
               Id = new Guid("2159f29c-6687-4c5e-bc03-3796321866c2"),
               Name = "Szálláshoz",
               Icon = "housing"
            },
            new AssetCategory
            {
               Id = new Guid("42863124-7b71-43e4-b30d-caf349382bf2"),
               Name = "Egyéb",
               Icon = "others"
            },
            new AssetCategory
            {
               Id = new Guid("4fb1477e-d5fa-47e8-a11c-80d03103256d"),
               Name = "Egészségügy",
               Icon = "healthcare",
            },
            new AssetCategory
            {
               Id = new Guid("8b6a4f75-21bb-474e-a6a1-6e7390f0aaa4"),
               Name = "Ruházat",
               Icon = "clothes"
            },
            new AssetCategory
            {
               Id = new Guid("98dc7404-86b7-492f-881d-0827dbb0e356"),
               Name = "Higiénia",
               Icon = "hygiene"
            },
            new AssetCategory
            {
               Id = new Guid("dff242f9-72e5-466e-8530-c7bd039fb774"),
               Name = "Logisztika",
               Icon = "logistics"
            },
            new AssetCategory
            {
               Id = new Guid("f10cbfa1-ceee-4e73-800c-07cbcb0f33af"),
               Name = "Emberi erőforrás",
               Icon = "hr"
            }
         };

         var assetTypes = new AssetType[]
         {
            new AssetType
            {
               Id = new Guid("09c430a8-fde5-4542-a489-b4aaab21f648"),
               Name = "Bébiétel, tápszer, tejpép, gabonapép",
               AssetCategoryId = assetCategories[0].Id,
            }
         };

         modelBuilder.Entity<AssetCategory>().HasData(assetCategories);
         modelBuilder.Entity<AssetType>().HasData(assetTypes);
      }
   }
}
