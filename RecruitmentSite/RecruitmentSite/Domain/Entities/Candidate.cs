namespace RecruitmentSite.Domain.Entities
{
    /// <summary>
    /// Modelo de entidad para representar un candidato en el sistema de reclutamiento.
    /// </summary>
    public class Candidate
    {
        public Candidate()
        {
            Experiences = new List<CandidateExperience>();
        }

        public int IdCandidate { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public required string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        // Relaciona las experiencias del candidato
        public ICollection<CandidateExperience> Experiences { get; set; }
    }
} 