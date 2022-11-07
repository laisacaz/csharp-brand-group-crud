using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Data
{
    public class BrandDataBase
    {
        private static List<Brand> brandsDb = new List<Brand>
        {
            new Brand{Id = 1, Active = true, Description = "Nike", MainSupplier = "NIKE CO."},
            new Brand{Id = 2, Active = true, Description = "Adidas", MainSupplier = "ADDs"},
            new Brand{Id = 3, Active = true, Description = "Puma", MainSupplier = "PUMAA Ltda."},
            new Brand{Id = 4, Active = false, Description = "Umbro", MainSupplier = "UMBR Company"},
            new Brand{Id = 5, Active = true, Description = "Penalty", MainSupplier = "Judges olievers"},
        };
        public List<Brand> Brands => brandsDb;

    }
}
