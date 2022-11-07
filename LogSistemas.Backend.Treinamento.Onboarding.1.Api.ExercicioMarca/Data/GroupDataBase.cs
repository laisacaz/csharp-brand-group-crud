using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Data
{
    public class GroupDataBase
    {
        private static List<Group> groupsDb = new List<Group>
        {
        new Group {Id = 1, EnableSubgroup = true, Description = "Lentes", Active = false},
        new Group {Id = 2, EnableSubgroup = true, Description = "Armações", Active = true},
        new Group {Id = 3, EnableSubgroup = true, Description = "Joias", Active = true},
        new Group {Id = 4, EnableSubgroup = false, Description = "Bonés", Active = true},

         };
        public List<Group> Groups => groupsDb;

    }
}
