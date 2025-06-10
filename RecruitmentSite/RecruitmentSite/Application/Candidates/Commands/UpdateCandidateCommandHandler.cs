using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentSite.Domain.Entities;
using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite.Application.Candidates.Commands
{
    /// <summary>
    /// Comando para actualizar un candidato en la base de datos.
    /// </summary>
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCandidateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync(c => c.IdCandidate == request.IdCandidate, cancellationToken);

            if (candidate == null)
            {
                throw new Exception($"Candidato con el id {request.IdCandidate} no se encuentra.");
            }

            candidate.Name = request.Name;
            candidate.Surname = request.Surname;
            candidate.Birthdate = request.Birthdate;
            candidate.Email = request.Email;
            candidate.ModifyDate = DateTime.UtcNow;

            var existingExperienceIds = candidate.Experiences.Select(e => e.IdCandidateExperience).ToList();
            var updatedExperienceIds = request.Experiences
                .Where(e => e.IdCandidateExperience.HasValue)
                .Select(e => e.IdCandidateExperience.Value)
                .ToList();

            // Elimina experiencias que ya no están en la solicitud
            var experiencesToRemove = candidate.Experiences
                .Where(e => !updatedExperienceIds.Contains(e.IdCandidateExperience))
                .ToList();

            foreach (var experience in experiencesToRemove)
            {
                _context.CandidateExperiences.Remove(experience);
            }

            // Actualiza o agrega experiencias
            foreach (var experienceDto in request.Experiences)
            {
                if (experienceDto.IdCandidateExperience.HasValue)
                {
                    // Actualiza experiencia existente
                    var existingExperience = candidate.Experiences
                        .FirstOrDefault(e => e.IdCandidateExperience == experienceDto.IdCandidateExperience.Value);

                    if (existingExperience != null)
                    {
                        existingExperience.Company = experienceDto.Company;
                        existingExperience.Job = experienceDto.Job;
                        existingExperience.Description = experienceDto.Description;
                        existingExperience.Salary = experienceDto.Salary;
                        existingExperience.BeginDate = experienceDto.BeginDate;
                        existingExperience.EndDate = experienceDto.EndDate;
                        existingExperience.ModifyDate = DateTime.UtcNow;
                    }
                }
                else
                {
                    // Agrega nueva experiencia
                    var newExperience = new CandidateExperience
                    {
                        IdCandidate = candidate.IdCandidate,
                        Company = experienceDto.Company,
                        Job = experienceDto.Job,
                        Description = experienceDto.Description,
                        Salary = experienceDto.Salary,
                        BeginDate = experienceDto.BeginDate,
                        EndDate = experienceDto.EndDate,
                        InsertDate = DateTime.UtcNow
                    };
                    _context.CandidateExperiences.Add(newExperience);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
} 