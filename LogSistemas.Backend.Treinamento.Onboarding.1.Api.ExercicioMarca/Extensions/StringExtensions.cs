namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Extensions
{
    public static class StringExtensions
    {
        public static bool IsFill(this string? str)
        {
            return !string.IsNullOrEmpty(str);
        }
    }
}
