using Job_Candidate_Hub_API.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Job_Candidate_Hub_API.Models;

public partial class Candidat
{
    public int CandidatId { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [PhoneNumberValidation]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [Required]
    public string? Email { get; set; }

    public string? TimeInterval { get; set; }

    [UrlLinkValidation]
    public string? LinkedinProfilUrl { get; set; }

    [UrlLinkValidation]
    public string? GithubProfilUrl { get; set; }

    [Required]
    public string? TextComment { get; set; }
}
