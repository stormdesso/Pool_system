let btnPass = document.querySelector('.js-btn-password'),
    inputPass = document.querySelector('.js-password-input');

btnPass.onclick = function ()
{
    if (inputPass.getAttribute('type') == 'password') {
        inputPass.setAttribute('type', 'text');
    }
    else
    {
        inputPass.setAttribute('type', 'password');
    }
}