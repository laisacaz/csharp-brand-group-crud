namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? EnableSubgroup { get; set; }
        public bool Active { get; set; } = true;
        public DateTime? Since { get; set; }
    }
}
