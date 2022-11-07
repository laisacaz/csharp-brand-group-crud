namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload
{
    public class BrandUpdatePayload
    {
        private int id;

        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }
        public bool Active { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? MainSupplier { get; set; }
        public DateTime? Since { get; set; }
    }
}