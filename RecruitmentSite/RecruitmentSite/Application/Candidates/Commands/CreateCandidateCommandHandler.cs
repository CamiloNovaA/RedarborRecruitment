using MediatR;
using RecruitmentSite.Domain.Entities;
using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite.Application.Candidates.Commands
{
    /// <summary>
    /// handler para crear un candidato.
    /// </summary>
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateCandidateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                Name = request.Name,
                Surname = request.Surname,
                Birthdate = request.Birthdate,
                Email = request.Email,
                InsertDate = DateTime.UtcNow
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            if (request.Experiences != null)
            {
                foreach (var exp in request.Experiences)
                {
                    var experience = new CandidateExperience
                    {
                        IdCandidate = candidate.IdCandidate,
                        Company = exp.Company,
                        Job = exp.Job,
                        Description = exp.Description,
                        Salary = exp.Salary,
                        BeginDate = exp.BeginDate,
                        EndDate = exp.EndDate,
                        InsertDate = DateTime.UtcNow
                    };
                    _context.CandidateExperiences.Add(experience);
                }
                await _context.SaveChangesAsync(cancellationToken);
            }

            return candidate.IdCandidate;
        }
    }
} 