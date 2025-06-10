using MediatR;

namespace RecruitmentSite.Application.Candidates.Commands
{
    /// <summary>
    /// comando para actualizar un candidato en la base de datos.
    /// </summary>
    public class UpdateCandidateCommand : IRequest<Unit>
    {
        public int IdCandidate { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public required string Email { get; set; }
        public List<UpdateCandidateExperienceDto> Experiences { get; set; } = new();
    }

    public class UpdateCandidateExperienceDto
    {
        public int? IdCandidateExperience { get; set; }
        public required string Company { get; set; }
        public required string Job { get; set; }
        public required string Description { get; set; }
        public int Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
} 