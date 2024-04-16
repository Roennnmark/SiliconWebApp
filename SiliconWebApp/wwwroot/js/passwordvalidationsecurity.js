const formErrorHandler = (element, validationResult) => {
    let spanElement = element.nextElementSibling;

    if (validationResult) {
        element.classList.remove('input-validation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-valid')
        spanElement.innerHTML = ''
    }
    else {
        element.classList.add('input-validation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-valid')
        spanElement.innerHTML = element.dataset.valRequired
    }
}

const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true)
    }
    else {
        formErrorHandler(element, false)
    }
}

const passwordValidator = (element) => {
    const regEx = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$/
    formErrorHandler(element, regEx.test(element.value))
}

let passwordFields = document.querySelectorAll('#form-current-password input, #form-new-password input, #form-confirm-new-password input');

passwordFields.forEach(input => {
    input.addEventListener('keyup', (e) => {
        switch (input.parentElement.id) {
            case 'form-current-password':
                passwordValidator(e.target)
                break;
            case 'form-new-password':
                passwordValidator(e.target)
                break;
            case 'form-confirm-new-password':
                passwordValidator(e.target)
                break;
        }
    })
})