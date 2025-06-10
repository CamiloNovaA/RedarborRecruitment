using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite.Application.Candidates.Queries
{
    /// <summary>
    /// Query para obtener um candidato por ID.
    /// </summary>
    public class GetCandidateByIdQuery : IRequest<CandidateDto>
    {
        public int IdCandidate { get; set; }
    }

    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
    {
        private readonly ApplicationDbContext _context;

        public GetCandidateByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CandidateDto> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync(c => c.IdCandidate == request.IdCandidate, cancellationToken);

            if (candidate == null)
            {
                throw new Exception($"Candidato con id {request.IdCandidate} no encontrado.");
            }

            return new CandidateDto
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthdate = candidate.Birthdate,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate,
                Experiences = candidate.Experiences.Select(e => new CandidateExperienceDto
                {
                    IdCandidateExperience = e.IdCandidateExperience,
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate
                }).ToList()
            };
        }
    }
} 