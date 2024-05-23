using System;
using System.Collections.Generic;

namespace Job_Candidate_Hub_API.Models;

public partial class Candidat
{
    public int CandidatId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? TimeInterval { get; set; }

    public string? LinkedinProfilUrl { get; set; }

    public string? GithubProfilUrl { get; set; }

    public string TextComment { get; set; } = null!;
}
