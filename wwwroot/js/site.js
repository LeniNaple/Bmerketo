try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })
} catch { }





///* VALIDATION CONTACT-FORM*/

const contactForm = document.getElementById('contact-form');
const contactName = document.getElementById('contact-name');
const contactEmail = document.getElementById('contact-email');
const contactMessage = document.getElementById('contact-message');


var validated = false;

contactForm.addEventListener("submit", (e) => {
    if (validated == false) {
        e.preventDefault();
        validateContactInputs();
    } else {
        contactForm.submit();
    }
})

const setCommentError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.contact-error');
    const list = element.classList;


    errorDisplay.innerText = message;
    inputControl.classList.add('contact-error');
    list.add("invalid");
    inputControl.classList.remove('success')
}

const setCommentSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.contact-error');
    const list = element.classList;

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('contact-error');
    list.remove("invalid");
};

const validateContactInputs = () => {

    if (contactName.value === '') {
        setCommentError(contactName, 'A name is required');
        validated = false;
    } else {
        setCommentSuccess(contactName);
        validated = true;
    }

    if (contactEmail.value === '') {
        setCommentError(contactEmail, 'An Email is required');
        validated = false;
    } else {
        setCommentSuccess(contactEmail);
        validated = true;
    }

    if (contactMessage.value === '') {
        setCommentError(contactMessage, 'A message is required');
        validated = false;
    } else if (contactMessage.value.length < 8) {
        setCommentError(contactMessage, 'Message must be at least 8 characters long.');
        validated = false;
    } else {
        setCommentSuccess(contactMessage);
        validated = true;
    }
};






/* VALIDATION SIGNUP-FORM*/

const signupForm = document.getElementById('signup-form');
const signupFirstName = document.getElementById('signup-firstName');
const signupLastName = document.getElementById('signup-lastName');
const signupEmail = document.getElementById('signup-email');
const signupPassword = document.getElementById('signup-password');
const signupConfirmPassword = document.getElementById('signup-confirmPassword');
const signupStreetName = document.getElementById('signup-streetName');


window.onload = function () {
    signupForm.addEventListener('submit', e => {
        e.preventDefault();
        validateSignupInputs();
    });
}


const setSignupError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.signup-error');
    const list = element.classList;


    errorDisplay.innerText = message;
    inputControl.classList.add('signup-error');
    list.add("invalid");
    inputControl.classList.remove('success')
}

const setSignupSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.signup-error');
    const list = element.classList;

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('signup-error');
    list.remove("invalid");
};

const isValidSignupEmail = signupEmail => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(signupEmail).toLowerCase());
}

const validateSignupInputs = () => {
    const signupFirstNameValue = signupFirstName.value.trim();
    const signupLastNameValue = signupLastName.value.trim();
    const signupEmailValue = signupEmail.value.trim();
    const signupPasswordValue = signupPassword.value.trim();
    const signupConfirmPasswordValue = signupConfirmPassword.value.trim();
    const signupStreetNameValue = signupStreetName.value.trim();


    if (signupFirstNameValue === '') {
        setSignupError(signupFirstName, 'First name is required');
    } else {
        setSignupSuccess(signupFirstName);
    }

    if (signupLastNameValue === '') {
        setSignupError(signupLastName, 'Last name is required');
    } else {
        setSignupSuccess(signupLastName);
    }

    if (signupEmailValue === '') {
        setSignupError(signupEmail, 'Email is required');
    } else if (!isValidSignupEmail(signupEmailValue)) {
        setSignupError(signupEmail, 'Provide a valid email address');
    } else {
        setSignupSuccess(signupEmail);
    }

    if (signupPasswordValue === '') {
        setSignupError(signupPassword, 'Password is required');
    } else if (signupPasswordValue.length < 8) {
        setSignupError(signupPassword, 'Password must be at least 8 characters long.');
    } else {
        setSignupSuccess(signupPassword);
    }


    if (signupConfirmPasswordValue === '') {
        setSignupError(signupConfirmPassword, 'Please confirm your password');
    } else if (signupConfirmPasswordValue !== signupPasswordValue) {
        setSignupError(signupConfirmPassword, "Passwords doesn't match");
    } else {
        setSignupSuccess(signupConfirmPassword);
    }

    if (signupStreetNameValue === '') {
        setSignupError(signupStreetName, 'A Street name is required');
    } else {
        setSignupSuccess(signupStreetName);
    }


    if (document.querySelectorAll('.success').length === 6) {
        signupForm.submit();
    }
};

