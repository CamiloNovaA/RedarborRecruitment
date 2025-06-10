using MediatR;

namespace RecruitmentSite.Application.Candidates.Commands
{
    /// <summary>
    /// Comando para eliminar un candidato.
    /// </summary>
    public class DeleteCandidateCommand : IRequest<Unit>
    {
        public int IdCandidate { get; set; }
    }
} 