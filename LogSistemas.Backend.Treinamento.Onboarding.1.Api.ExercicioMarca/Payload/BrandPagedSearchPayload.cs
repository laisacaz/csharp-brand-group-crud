
namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload
{
    /// <summary>
    /// Filters to be filtered
    /// </summary>
    public class BrandPagedSearchPayload : BasePagedSearchPayload
    {
        /// <summary>
        /// <code>True</code> = Actives
        /// <para><code>False</code>= Inactives</para>
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// It considers all brands containing this Main Supplier
        /// </summary>
        public string? MainSupplier { get; set; } = string.Empty;
        /// <summary>
        /// It considers all brands containing this Description
        /// </summary>
        public string? Description { get; set; } = string.Empty;

    }
}