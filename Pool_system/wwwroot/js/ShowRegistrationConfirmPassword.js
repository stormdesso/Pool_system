let btnRegistrationConfirmPass = document.querySelector('.js-registration-confirm-btn-password'),
    inputRegistrationConfirmPass = document.querySelector('.js-registration-confirm-password-input');

btnRegistrationConfirmPass.onclick = function ()
{
    if (inputRegistrationConfirmPass.getAttribute('type') == 'password') {
        inputRegistrationConfirmPass.setAttribute('type', 'text');
    }
    else
    {
        inputRegistrationConfirmPass.setAttribute('type', 'password');
    }
}