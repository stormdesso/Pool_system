let btnPass = document.querySelector('.js-btn-password'),
    inputPass = document.querySelector('.js-password-input');

btnPass.onclick = function ()
{
    if (inputPass.getAttribute('type') == 'password') {
        btnPass.classList.add('active');
        inputPass.setAttribute('type', 'text');
    }
    else
    {
        btnPass.classList.remove('active');
        inputPass.setAttribute('type', 'password');
    }
}