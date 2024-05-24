using Job_Candidate_Hub_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Job_Candidate_Hub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly JobCandidateHubContext _context;

        public CandidatController(JobCandidateHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Candidat>>> GetAllCandidat()
        {
            try
            {
                var Candidats = await _context.Candidats.ToListAsync();

                if (Candidats == null)
                {
                    return NoContent();
                }

                return Candidats;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidat>> GetCandidatById(int id)
        {
            try
            {
                var Candidat = await _context.Candidats.FindAsync(id);

                if (Candidat == null)
                {
                    return NotFound();
                }

                return Candidat;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // Check If Candidat Exists Method
        private async Task<Candidat> CandidatExist(string email)
        {
            var ExistCandidat = await _context.Candidats.Where(c => c.Email == email).FirstOrDefaultAsync();

            return ExistCandidat;
        }

        // Update Candidat If Exists Method
        private async Task<ActionResult<Candidat>> UpdateExistCandidat(Candidat candidatToUpdate, Candidat candidat)
        {
            try
            {
                candidatToUpdate.FirstName = candidat.FirstName;
                candidatToUpdate.LastName = candidat.LastName;
                candidatToUpdate.PhoneNumber = candidat.PhoneNumber;
                candidatToUpdate.TimeInterval = candidat.TimeInterval;
                candidatToUpdate.LinkedinProfilUrl = candidat.LinkedinProfilUrl;
                candidatToUpdate.GithubProfilUrl = candidat.GithubProfilUrl;
                candidatToUpdate.TextComment = candidat.TextComment;

                _context.Candidats.Update(candidatToUpdate);

                _context.Entry(candidatToUpdate).Property("Email").IsModified = false;

                await _context.SaveChangesAsync();

                return Ok("Candidat updated successfully");
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Candidat>> CreateCandidat(Candidat candidat)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ExistCandidat = await CandidatExist(candidat.Email);

                if (ExistCandidat != null)
                {
                    return await UpdateExistCandidat(ExistCandidat, candidat);
                }

                await _context.AddAsync(candidat);

                await _context.SaveChangesAsync();

                return Ok("Candidat added successfully");

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
