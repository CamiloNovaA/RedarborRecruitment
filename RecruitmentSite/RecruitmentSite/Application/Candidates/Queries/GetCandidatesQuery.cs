using MediatR;

namespace RecruitmentSite.Application.Candidates.Queries
{
    /// <summary>
    /// Query para obtener la lista de candidatos.
    /// </summary>
    public class GetCandidatesQuery : IRequest<List<CandidateDto>>
    {
    }

    public class CandidateDto
    {
        public CandidateDto()
        {
            Experiences = new List<CandidateExperienceDto>();
        }

        public int IdCandidate { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public required string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public List<CandidateExperienceDto> Experiences { get; set; }
    }

    public class CandidateExperienceDto
    {
        public int IdCandidateExperience { get; set; }
        public required string Company { get; set; }
        public required string Job { get; set; }
        public required string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
} 