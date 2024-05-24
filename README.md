- ValidationAttributes explanation:
  -> PhoneNumberValidationAttribute : it validate if the Phone Number inserted if it has the correct phone format and not make the column required
  -> UrlLinkValidationAttribute : it validate if the Urls Linkedin & Github inserted if they have the correct url format and not make the column required

- Explanation of the Controller Actions : 
  -> GetAllCandidat: it retreives all the candidats in the table from the dabatabase 
  -> GetCandidatByEmail: it reteives a candidat data by his/her email
  -> CreateCandidat: Insert/Create a new candidat in the database and if it exists which is done by CandidatExist function and it update it insted calling the function UpdateExistCandidat
  -> CandidatExist: search if the a candidat exist by the email
  -> UpdateExistCandidat: update the existed candidat data but not hi

- Total time spent 2 to 3 horus 
