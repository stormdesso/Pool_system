let btnPass = document.querySelector('.js-btn-password')

btnPass.forEach(function (btn) {
    btn.onclick = function () {
        let target = this.getAttribute('data-target'),
            inputPass = document.querySelector(target);

        if (inputPass.getAttribute('type') == 'password') {
            btn.classList.add('active');
            inputPass.setAttribute('type', 'text');
        }
        else {
            btn.classList.remove('active');
            inputPass.setAttribute('type', 'password');
        }

    }
});

