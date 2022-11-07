namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities
{
    public class Brand
    {
        public DateTime? Since { get; set; }
        public bool Active { get; set; } = true;
        public string Description { get; set; }
        public int Id { get; set; }
        public string? MainSupplier { get; set; }
    }
}