using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RepoPattern_Repo
{
    public enum ClaimType
    {        
        Car = 1,
        Home,
        Theft
    }
    public class ClaimsContent
    {        
        public string ClaimId { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public ClaimType TypeOfClaim { get; set; }

        public ClaimsContent() { }

        public ClaimsContent(string claimId, string desciption, double claimAmount, string dateOfIncident, string dateOfClaim, bool isValid, ClaimType claim)
        {
            ClaimId = claimId;
            Description = desciption;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            TypeOfClaim = claim;
        }        
         

    }
   
}

