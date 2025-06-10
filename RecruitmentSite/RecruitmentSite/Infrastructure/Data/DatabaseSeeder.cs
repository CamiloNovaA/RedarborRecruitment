using RecruitmentSite.Domain.Entities;

namespace RecruitmentSite.Infrastructure.Data
{
    /// <summary>
    /// Clase para inicializar la base de datos con datos de prueba.
    /// </summary>
    public static class DatabaseSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Asegurarse de que la base de datos está creada
            context.Database.EnsureCreated();

            // Verificar si ya hay datos
            if (context.Candidates.Any())
                return;

            // Agregar candidatos de prueba
            var candidates = new List<Candidate>
            {
                new() {
                    Name = "Juan",
                    Surname = "Pérez",
                    Birthdate = new DateTime(1990, 5, 15),
                    Email = "juan.perez@redarbor.com",
                    InsertDate = DateTime.UtcNow,
                    Experiences =
                    [
                        new CandidateExperience
                        {
                            Company = "Interrapidisimo",
                            Job = "Desarrollador Junior",
                            Description = "Desarrollo de aplicaciones web",
                            Salary = 2800000M,
                            BeginDate = new DateTime(2015, 1, 1),
                            EndDate = new DateTime(2017, 6, 30),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Axa",
                            Job = "Desarrollador Senior",
                            Description = "Desarrollo de aplicaciones web",
                            Salary = 4800000M,
                            BeginDate = new DateTime(2017, 7, 1),
                            EndDate = new DateTime(2021, 12, 31),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Redarbor",
                            Job = "Lider tecnico",
                            Description = "Liderazgo de equipo",
                            Salary = 7800000M,
                            BeginDate = new DateTime(2022, 1, 1),
                            EndDate = null, // Trabajo actual
                            InsertDate = DateTime.UtcNow
                        }
                    ]
                },
                new() {
                    Name = "María",
                    Surname = "González",
                    Birthdate = new DateTime(1995, 8, 20),
                    Email = "maria.gonzalez@redarbor.com",
                    InsertDate = DateTime.UtcNow,
                    Experiences =
                    [
                        new CandidateExperience
                        {
                            Company = "Consultora ABC",
                            Job = "Analista de Sistemas Junior",
                            Description = "Análisis y diseño",
                            Salary = 2800000M,
                            BeginDate = new DateTime(2018, 3, 1),
                            EndDate = new DateTime(2019, 12, 31),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Globant",
                            Job = "Analista de Sistemas Senior",
                            Description = "Diseño y arquitectura",
                            Salary = 4800000M,
                            BeginDate = new DateTime(2020, 1, 1),
                            EndDate = null, // Trabajo actual
                            InsertDate = DateTime.UtcNow
                        }
                    ]
                },
                new() {
                    Name = "Carlos",
                    Surname = "Rodríguez",
                    Birthdate = new DateTime(1988, 12, 10),
                    Email = "carlos.rodriguez@redarbor.com",
                    InsertDate = DateTime.UtcNow,
                    Experiences = new List<CandidateExperience>
                    {
                        new CandidateExperience
                        {
                            Company = "IT Qualis",
                            Job = "Desarrollador Full Stack",
                            Description = "Desarrollo full stack",
                            Salary = 4800000M,
                            BeginDate = new DateTime(2015, 6, 1),
                            EndDate = new DateTime(2018, 12, 31),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Tech Inc",
                            Job = "Arquitecto de Software",
                            Description = "Diseño de arquitectura",
                            Salary = 7800000M,
                            BeginDate = new DateTime(2019, 1, 1),
                            EndDate = new DateTime(2022, 6, 30),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Claro SA",
                            Job = "Lider de arquitectura",
                            Description = "Liderazgo de arquitectura",
                            Salary = 9800000M,
                            BeginDate = new DateTime(2022, 7, 1),
                            EndDate = null, // Trabajo actual
                            InsertDate = DateTime.UtcNow
                        }
                    }
                },
                new() {
                    Name = "Ana",
                    Surname = "Martínez",
                    Birthdate = new DateTime(1993, 3, 25),
                    Email = "ana.martinez@redarbor.com",
                    InsertDate = DateTime.UtcNow,
                    Experiences = new List<CandidateExperience>
                    {
                        new CandidateExperience
                        {
                            Company = "Data SAS",
                            Job = "Analista de datos",
                            Description = "Análisis de datos",
                            Salary = 1800000M,
                            BeginDate = new DateTime(2017, 1, 1),
                            EndDate = new DateTime(2019, 12, 31),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Big Solutions",
                            Job = "Ingeniero de datos",
                            Description = "Desarrollo de datos",
                            Salary = 5800000M,
                            BeginDate = new DateTime(2020, 1, 1),
                            EndDate = null, // Trabajo actual
                            InsertDate = DateTime.UtcNow
                        }
                    }
                },
                new() {
                    Name = "Angel",
                    Surname = "García",
                    Birthdate = new DateTime(1991, 7, 8),
                    Email = "luis.garcia@redarbor.com",
                    InsertDate = DateTime.UtcNow,
                    Experiences =
                    [
                        new CandidateExperience
                        {
                            Company = "Android",
                            Job = "Desarrollador Movil",
                            Description = "Desarrollo de aplicaciones móviles",
                            Salary = 3800000M,
                            BeginDate = new DateTime(2016, 3, 1),
                            EndDate = new DateTime(2018, 8, 31),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Huawei",
                            Job = "Desarrollador Movil senior",
                            Description = "Desarrollo de aplicaciones móviles",
                            Salary = 5800000M,
                            BeginDate = new DateTime(2018, 9, 1),
                            EndDate = new DateTime(2021, 12, 31),
                            InsertDate = DateTime.UtcNow
                        },
                        new CandidateExperience
                        {
                            Company = "Apple",
                            Job = "Lider de desarrollo movil",
                            Description = "Liderazgo de equipo de desarrollo móvil",
                            Salary = 7800000M,
                            BeginDate = new DateTime(2022, 1, 1),
                            EndDate = null, // Trabajo actual
                            InsertDate = DateTime.UtcNow
                        }
                    ]
                }
            };

            context.Candidates.AddRange(candidates);
            context.SaveChanges();
        }
    }
} 