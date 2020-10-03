using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RepoPattern_Repo
{
    public class ClaimsContentRepo
    {
        private List<ClaimsContent> _listOfContent = new List<ClaimsContent>();
        
        //Create
        public void AddContentToList(ClaimsContent content)
        {
            _listOfContent.Add(content);
        }

        //Read
        public List<ClaimsContent> GetContentList()
        {
            return _listOfContent;
        }

        //Update
        public void UpdateExistingContent(string originalClaimId, ClaimsContent newContent)
        {
            //Find the content
            ClaimsContent oldContent = GetContentByClaimId(originalClaimId);

            //Update the content
            if (oldContent != null)
            {
                oldContent.ClaimId = newContent.ClaimId;
                oldContent.TypeOfClaim = newContent.TypeOfClaim;
                oldContent.Description = newContent.Description;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.IsValid = newContent.IsValid;
            }
        }

        //Delete
        public bool RemoveContentFromList(string claimId)
        {
            ClaimsContent content = GetContentByClaimId(claimId);

            if(content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(content);

            if (initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        //Helper Method
        public ClaimsContent GetContentByClaimId(string claimId)
        {
            foreach (ClaimsContent content in _listOfContent)
            {
                if (content.ClaimId.ToLower() == claimId)
                {
                    return content;
                }
            }

            return null;
            
        }

    }
}
