using System.ComponentModel.DataAnnotations;
using MediatR;

namespace RecruitmentSite.Application.Candidates.Commands
{
    /// <summary>
    /// Comand para crear un candidato.
    /// </summary>
    public class CreateCandidateCommand : IRequest<int>
    {
        public CreateCandidateCommand()
        {
            Experiences = [];
        }

        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [MinimumAge(18, ErrorMessage = "Debes ser mayor de edad (18 años) para registrarte")]
        public DateTime Birthdate { get; set; }

        public List<CandidateExperienceDto> Experiences { get; set; }
    }

    public class CandidateExperienceDto
    {
        public required string Company { get; set; }
        public required string Job { get; set; }
        public required string Description { get; set; }
        public int Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        /// <summary>
        /// Valida el valor minimo de edad para un candidato.
        /// </summary>
        /// <param name="minimumAge"></param>
        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        /// <summary>
        /// Valida si la fecha de nacimiento cumple con la edad mínima requerida.
        /// </summary>
        /// <param name="value">Fecha ingresada</param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;

                if (birthDate.Date > today.AddYears(-age)) age--;

                if (age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}