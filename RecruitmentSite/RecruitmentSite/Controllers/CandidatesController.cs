using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSite.Application.Candidates.Commands;
using RecruitmentSite.Application.Candidates.Queries;

namespace RecruitmentSite.Controllers
{
    /// <summary>
    /// Controlador para gestionar candidatos en el sistema de reclutamiento.
    /// </summary>
    public class CandidatesController : Controller
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var candidates = await _mediator.Send(new GetCandidatesQuery());
            return View(candidates);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCandidateCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var candidateId = await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(command);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateByIdQuery { IdCandidate = id });
            var command = new UpdateCandidateCommand
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthdate = candidate.Birthdate,
                Email = candidate.Email,
                Experiences = candidate.Experiences.Select(e => new UpdateCandidateExperienceDto
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
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCandidateCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCandidateCommand { IdCandidate = id });
            return RedirectToAction(nameof(Index));
        }
    }
} 