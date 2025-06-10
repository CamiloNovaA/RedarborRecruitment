namespace RecruitmentSite.Domain.Entities
{
    /// <summary>
    /// Modelo de entidad para representar la experiencia que un candidato tiene.
    /// </summary>
    public class CandidateExperience
    {
        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public required string Company { get; set; }
        public required string Job { get; set; }
        public required string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public Candidate? Candidate { get; set; }
    }
} 