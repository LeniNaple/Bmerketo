﻿try {
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





///* VALIDATION FOR CONTACT FORM*/

//const contactForm = document.getElementById('contact-form');
//const contactName = document.getElementById('contact-name');
//const contactEmail = document.getElementById('contact-email');
//const contactMessage = document.getElementById('contact-message');

//contactForm.addEventListener('submit', e => {
//    e.preventDefault();
//    validateContactInputs();

//});

//const setContactError = (element, message) => {
//    const inputControl = element.parentElement;
//    const errorDisplay = inputControl.querySelector('.contact-error');
//    const list = element.classList;


//    errorDisplay.innerText = message;
//    inputControl.classList.add('contact-error');
//    list.add("invalid");
//    inputControl.classList.remove('success')
//}

//const setContactSuccess = element => {
//    const inputControl = element.parentElement;
//    const errorDisplay = inputControl.querySelector('.contact-error');
//    const list = element.classList;

//    errorDisplay.innerText = '';
//    inputControl.classList.add('success');
//    inputControl.classList.remove('contact-error');
//    list.remove("invalid");
//};

//const isValidContactEmail = contactEmail => {
//    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
//    return re.test(String(contactEmail).toLowerCase());
//}

//const validateContactInputs = () => {
//    const contactNameValue = contactName.value.trim();
//    const contactEmailValue = contactEmail.value.trim();
//    const contactMessageValue = contactMessage.value.trim();


//    if (contactNameValue === '') {
//        setContactError(contactName, 'Username is required');
//    } else {
//        setContactSuccess(contactName);
//    }

//    if (contactEmailValue === '') {
//        setContactError(contactEmail, 'Email is required');
//    } else if (!isValidContactEmail(contactEmailValue)) {
//        setContactError(contactEmail, 'Provide a valid email address');
//    } else {
//        setContactSuccess(contactEmail);
//    }

//    if (contactMessageValue === '') {
//        setContactError(contactMessage, 'Message is required');
//    } else if (contactMessageValue.length < 20) {
//        setContactError(contactMessage, 'Message must be at least 20 characters long.');
//    } else {
//        setContactSuccess(contactMessage);
//    }

//    if (document.querySelectorAll('.success').length === 3) {
//        // submit the form
//        contactForm.submit();
//    }
//};








/* VALIDATION FOR SIGNUP  FORM*/


const signupForm = document.getElementById('signup-form');
const signupFirstName = document.getElementById('signup-firstName');
const signupLastName = document.getElementById('signup-lastName');
const signupEmail = document.getElementById('signup-email');
const signupPassword = document.getElementById('signup-password');
const signupConfirmPassword = document.getElementById('signup-confirmPassword');


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


    if (document.querySelectorAll('.success').length === 5) {
        signupForm.submit();
    }
};

