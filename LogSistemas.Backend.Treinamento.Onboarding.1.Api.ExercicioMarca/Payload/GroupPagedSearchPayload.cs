namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload
{

    public class GroupPagedSearchPayload : BasePagedSearchPayload
    {
        public string? Description { get; set; }
        public int? Id { get; set; }
        public bool? EnableSubgroup { get; set; }
        public bool Active { get; set; }

    }
}
