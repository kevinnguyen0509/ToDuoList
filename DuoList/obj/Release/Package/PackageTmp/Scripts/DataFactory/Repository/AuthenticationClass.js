let baseUrl = document.getElementById('HiddenCurrentUrl').value;

export class AuthenticationClass{
    constructor(CurrentForm){
        this.CurrentForm = CurrentForm;
    }

   async VerifyLogin() {
       return await $.ajax({
           type: "Post",
           url: baseUrl + 'Authentication/LoginVerification',
           data: $(this.CurrentForm).serialize(),
           success: function (SucessResult) {
               //If login was successful return Success, else Failed
               return SucessResult;
           }
       });
    }

}

