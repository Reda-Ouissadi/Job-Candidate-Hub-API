- ValidationAttributes explanation:
  
  -> PhoneNumberValidationAttribute : it validate if the Phone Number inserted if it has the correct phone format and not make the column required
  
  -> UrlLinkedInValidationAttribute : it validate if the Linkedin Porfile Url is inserted correctly, it must start with https://www.linkedin.com/in/ then whatever profile name it has after it
  
  -> UrlLinkedInValidationAttribute : iit validate if the GitHub Porfile Url is inserted correctly, it must start with https://github.com/ then whatever profile name it has after it

- Explanation of the Controller Actions :
    
  -> CreateCandidat: Insert/Create a new candidat in the database and if it exists which is done by CandidatExist function and it update it insted calling the function UpdateExistCandidat
  
  -> CandidatExist: search if the a candidat exist by the email
  
  -> UpdateExistCandidat: update the existed candidat data but not his email

- Total time spent 2 to 3 horus 
