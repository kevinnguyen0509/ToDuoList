import { AuthenticationClass } from "../../DataFactory/Repository/AuthenticationClass.js";
let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let LoginForm = document.getElementById("LoginForm");
let LoginOptions = new AuthenticationClass(LoginForm);

$(document).ready(function () {

    //Attaches a listener onto the login form to handle the login process
    LoginForm.addEventListener('submit', function (event) {
        event.preventDefault();

        //Save the successResponse so we can take action if the result was a
        //success or a fail
        let verifyLogin = LoginOptions.VerifyLogin();

        verifyLogin.then(function (SuccessReponse) {
            if (SuccessReponse.toUpperCase() == "Success".toUpperCase()) {
                window.location.href = baseUrl ;
            }
            else {
                console.log("hmmm..thats not good it..", SuccessReponse)
            }
            
        });
    })
    
})