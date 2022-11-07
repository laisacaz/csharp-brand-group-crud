namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload
{
    public class GroupUpdatePayload
    {
        private int Id;
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            this.Id = id;
        }
        public bool? EnableSubgroup { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? Since { get; set; }
        public bool Active { get; set; }
    }
}
