let btnPass1 = document.querySelector('.js-btn-password1'),
    inputPass1 = document.querySelector('#js-first-password'),
    btnPass2 = document.querySelector('.js-btn-password2'),
    inputPass2 = document.querySelector('#js-second-password');

btnPass1.onclick = function () {
    if (inputPass1.getAttribute('type') == 'password') {
        btnPass1.classList.add('active');
        inputPass1.setAttribute('type', 'text');
    }
    else {
        btnPass1.classList.remove('active');
        inputPass1.setAttribute('type', 'password');
    }
}

btnPass2.onclick = function () {
    if (inputPass2.getAttribute('type') == 'password') {
        btnPass2.classList.add('active');
        inputPass2.setAttribute('type', 'text');
    }
    else {
        btnPass2.classList.remove('active');
        inputPass2.setAttribute('type', 'password');
    }
}

