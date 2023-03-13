let btnRegistrationPass = document.querySelector('.js-btn-registration-password'),
    inputRegistrationPass = document.querySelector('.js-registration-password-input');

btnRegistrationPass.onclick = function ()
{
    if (inputRegistrationPass.getAttribute('type') == 'password') {
        inputRegistrationPass.setAttribute('type', 'text');
    }
    else
    {
        inputRegistrationPass.setAttribute('type', 'password');
    }
}