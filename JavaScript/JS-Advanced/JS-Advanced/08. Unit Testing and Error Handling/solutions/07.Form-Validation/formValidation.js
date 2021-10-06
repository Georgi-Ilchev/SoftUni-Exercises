//88 points
function validate() {
    const userNamePattern = /^[A-Za-z0-9]{3,20}$/;
    const passwordPattern = /^[A-Za-z0-9_]{5,15}$/;
    const emailPattern = /@(\w)*\./;

    let isValidInput = true;
    let isChecked = false;

    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', (ev) => {
        ev.preventDefault();

        //username
        const usernameField = document.getElementById('username');
        if (!userNamePattern.test(usernameField.value)) {
            isValidInput = false;
            usernameField.style.borderColor = 'red';
        } else {
            usernameField.style.borderColor = 'none';
        }

        //password
        const passwordField = document.getElementById('password');
        const confirmpasswordField = document.getElementById('confirm-password');

        if (!passwordPattern.test(passwordField.value) && !passwordPattern.test(confirmpasswordField.value) ||
            passwordField.value != confirmpasswordField.value) {
            isValidInput = false;
            passwordField.style.borderColor = 'red';
            confirmpasswordField.style.borderColor = 'red';
        } else {
            passwordField.style.borderColor = 'none';
            confirmpasswordField.style.borderColor = 'none';
        }

        //email
        const emailField = document.getElementById('email');
        if (!emailPattern.test(emailField.value)) {
            isValidInput = false;
            emailField.style.borderColor = 'red';
        } else {
            emailField.style.borderColor = 'none';
        }

        const validDiv = document.getElementById('valid');
        if (isValidInput) {
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }

        if (isChecked) {
            const companyNum = document.getElementById('companyNumber');

            if (Number(companyNum.value) < 1000 || Number(companyNum.value) > 9999) {
                companyNum.style.borderColor = 'red';
            } else {
                companyNum.style.borderColor = 'none';
            }
        }
    });

    document.getElementById('company').addEventListener('change', (ev) => {
        const companyField = document.getElementById('companyInfo');

        if (ev.target.checked) {
            isChecked = true;
            companyField.style.display = 'block';
        } else {
            isChecked = false;
            companyField.style.display = 'none';
        }
    });
}

//100 points
function validate() {
    const usernamePattern = /^[A-Za-z0-9]{3,20}$/;
    const emailPattern = /@(\w)*\./;
    const passwordPattern = /^[A-Za-z0-9_]{5,15}$/;
    const companyNumberPattern = /^[0-9]{4}$/;

    const username = document.getElementById('username');
    const email = document.getElementById('email');
    const password = document.getElementById('password');
    const confPassword = document.getElementById('confirm-password');
    const companyInfo = document.getElementById('companyInfo');
    const companyNumber = document.getElementById('companyNumber');
    const valid = document.getElementById('valid');

    let isValid;

    const companyCheck = document.getElementById('company');
    companyCheck.addEventListener('change', onCheck);

    const submit = document.getElementById('submit');
    submit.addEventListener('click', onSubmit);

    function onSubmit(ev) {
        ev.preventDefault();
        isValid = true;

        //username
        if (!usernamePattern.test(username.value)) {
            username.style.borderColor = 'red';
            isValid = false;
        } else {
            username.style.borderColor = '';
        }

        //email
        if (!emailPattern.test(email.value)) {
            email.style.borderColor = 'red';
            isValid = false;
        } else {
            email.style.borderColor = '';
        }

        //password
        if (!passwordPattern.test(password.value) ||
            !passwordPattern.test(confPassword.value) ||
            password.value != confPassword.value) {

            password.style.borderColor = 'red';
            confPassword.style.borderColor = 'red';
            isValid = false;
        } else {
            password.style.borderColor = '';
            confPassword.style.borderColor = '';
        }

        if (companyInfo.style.display == 'block') {
            if (!companyNumberPattern.test(companyNumber.value)) {
                companyNumber.style.borderColor = 'red';
                isValid = false;
            } else {
                companyNumber.style.borderColor = '';
            }
        } else {
            companyNumber.style.borderColor = '';
        }

        if (isValid) {
            valid.style.display = 'block';
        } else {
            valid.style.display = 'none';
        }
    }

    function onCheck(ev) {
        if (companyInfo.style.display == 'none') {
            companyInfo.style.display = 'block';
        } else {
            companyInfo.style.display = 'none';
        }
    }
}