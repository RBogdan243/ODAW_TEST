using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ODAW_TEST.Data;
using ODAW_TEST.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ODAW_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SchoolController : ControllerBase
    {
        private readonly ODAWContext _odawcontext;

        public SchoolController(ODAWContext odawcontext)
        {
            _odawcontext = odawcontext;
        }

        [HttpGet("Lista_Profesori")]
        public async Task<IActionResult> GetProfesorMaterieJoin()
        {
            var profesorMaterieJoin = await _odawcontext.Profesori
                .Join(_odawcontext.ProfesorMaterie,
                      profesor => profesor.Id,
                      profesorMaterie => profesorMaterie.ProfesorId,
                      (profesor, profesorMaterie) => new { profesor, profesorMaterie })
                .Select(x => new
                {
                    IdProfesor = x.profesor.Id,
                    Nume = x.profesor.Nume + ' ' + x.profesor.Prenume,
                    TipProfesor = x.profesor.Tip_Profesor,
                    Salariu = x.profesor.Salariu,
                    Materie = x.profesorMaterie.materie.Nume
                }).ToListAsync();

            return Ok(profesorMaterieJoin);
        }

        [HttpGet("Lista_Materii")]
        public async Task<IActionResult> GetMaterii()
        {
            var Materii = await _odawcontext.Materii
                .ToListAsync();

            return Ok(Materii);
        }

        [HttpPost("Creeaza_Materii+Profesori")]
        public async Task<IActionResult> Creaza([FromBody] Profesor profesor, [FromQuery] Materie materie)
        {
            var prof = new Profesor
            {
                Id = Guid.NewGuid(),
                Nume = profesor.Nume,
                Prenume = profesor.Prenume,
                Tip_Profesor = profesor.Tip_Profesor,
                Salariu = profesor.Salariu,
                DateCreated = DateTime.Now
        };

            var Mat = new Materie
            {
                Id = Guid.NewGuid(),
                Nume = materie.Nume,
                Descriere = materie.Descriere,
                DateCreated = DateTime.Now
            };

            var profMat = new ProfesorMaterie
            {
                ProfesorId = profesor.Id,
                prof = prof,
                MaterieId = materie.Id,
                materie = Mat
            };

            prof.ProfesorMaterie.Add(profMat);
            Mat.ProfesorMaterie.Add(profMat);

            await _odawcontext.AddAsync(prof);
            await _odawcontext.AddAsync(Mat);
            await _odawcontext.AddAsync(profMat);
            await _odawcontext.SaveChangesAsync();

            return Ok(new { message = "Materia si Profesorul au fost adaugati." });
        }

        [HttpPut("Adauga_Profesor")]
        public async Task<IActionResult> CreazaProf([FromBody] Profesor profesor, [FromQuery] Materie materie)
        {
            var prof = new Profesor
            {
                Id = Guid.NewGuid(),
                Nume = profesor.Nume,
                Prenume = profesor.Prenume,
                Tip_Profesor = profesor.Tip_Profesor,
                Salariu = profesor.Salariu,
                DateCreated = DateTime.Now
            };

            var Mat = await _odawcontext.Materii
                .Where(p =>  p.Id == materie.Id)
                .FirstOrDefaultAsync();

            if (Mat != null)
            {
                var profMat = new ProfesorMaterie
                {
                    ProfesorId = profesor.Id,
                    prof = prof,
                    MaterieId = materie.Id,
                    materie = Mat
                };

                prof.ProfesorMaterie.Add(profMat);
                Mat.ProfesorMaterie.Add(profMat);

                await _odawcontext.AddAsync(prof);
                await _odawcontext.AddAsync(Mat);
                await _odawcontext.AddAsync(profMat);
                await _odawcontext.SaveChangesAsync();

                return Ok(new { message = "Profesorul a fost adaugat cu succes." });
            }
            else return BadRequest(new { message = "Materia adaugata nu exista!" });
        }

        [HttpDelete("Sterge_Profesor")]
        public async Task<IActionResult> StergeProf([FromBody] Profesor profesor)
        {
            var prof = await _odawcontext.Profesori
                .Where(p => p.Id == profesor.Id)
                .FirstOrDefaultAsync();
            if (prof != null)
            { 
                _odawcontext.Profesori.Remove(prof);
                await _odawcontext.SaveChangesAsync();

                return Ok(new { message = "Profesorul a fost sters cu succes." });
            }
            else return BadRequest(new { message = "Proful selectat nu exista!" });
        }

        [HttpDelete("Sterge_Materie")]
        public async Task<IActionResult> StergeMat([FromBody] Materie materie)
        {
            var Mat = await _odawcontext.Materii
                .Where(p => p.Id == materie.Id)
                .FirstOrDefaultAsync();
            if (Mat != null)
            {
                _odawcontext.Materii.Remove(Mat);
                await _odawcontext.SaveChangesAsync();

                return Ok(new { message = "Materia a fost stersa cu succes." });
            }
            else return BadRequest(new { message = "Materia selectata nu exista!" });
        }
    }
}
