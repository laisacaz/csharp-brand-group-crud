namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO
{
    public class BasePagedSearchDTO<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int RecordCount { get; set; }

    }
}
