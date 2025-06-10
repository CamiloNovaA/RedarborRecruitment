using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite.Application.Candidates.Queries
{
    /// <summary>
    /// Handler para la consulta de obtener candidatos.
    /// </summary>
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<CandidateDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetCandidatesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CandidateDto>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Candidates
                .Include(c => c.Experiences)
                .Select(c => new CandidateDto
                {
                    IdCandidate = c.IdCandidate,
                    Name = c.Name,
                    Surname = c.Surname,
                    Birthdate = c.Birthdate,
                    Email = c.Email,
                    InsertDate = c.InsertDate,
                    ModifyDate = c.ModifyDate,
                    Experiences = c.Experiences.Select(e => new CandidateExperienceDto
                    {
                        IdCandidateExperience = e.IdCandidateExperience,
                        Company = e.Company,
                        Job = e.Job,
                        Description = e.Description,
                        Salary = e.Salary,
                        BeginDate = e.BeginDate,
                        EndDate = e.EndDate
                    }).ToList()
                })
                .ToListAsync(cancellationToken);
        }
    }
} 