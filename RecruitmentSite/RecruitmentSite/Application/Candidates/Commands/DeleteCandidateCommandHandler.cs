using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite.Application.Candidates.Commands
{
    /// <summary>
    /// handler para el comando de eliminación de un candidato.
    /// </summary>
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCandidateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync(c => c.IdCandidate == request.IdCandidate, cancellationToken);

            if (candidate != null)
            {
                _context.CandidateExperiences.RemoveRange(candidate.Experiences);
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
} 