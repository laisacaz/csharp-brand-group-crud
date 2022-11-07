namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload
{
    public enum Type
    {
        Food,
        Clothes,
        Others
    }
    public class BrandInsertPayload
    {
        public string Description { get; set; }
        public string? MainSupplier { get; set; }
        public DateTime? Since { get; set; }
        public Type type { get; set; }
    }

}