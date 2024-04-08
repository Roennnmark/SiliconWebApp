document.addEventListener('DOMContentLoaded', function () {
    const formErrorHandler = (element, validationResult) => {
        let spanElement = element.closest('.input-group').querySelector(`[asp-validation-for="${element.name}"]`);

        if (validationResult) {
            element.classList.remove('input-validation-error');
            spanElement.classList.remove('field-validation-error');
            spanElement.classList.add('field-validation-valid');
            spanElement.innerHTML = '';
        } else {
            element.classList.add('input-validation-error');
            spanElement.classList.add('field-validation-error');
            spanElement.classList.remove('field-validation-valid');
            spanElement.innerHTML = 'Required field';
        }
    };

    const textValidator = (element, minLength = 2) => {
        if (element.value.length >= minLength) {
            formErrorHandler(element, true);
        } else {
            formErrorHandler(element, false);
        }
    };

    const emailValidator = (element) => {
        const regEx = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        formErrorHandler(element, regEx.test(element.value));
    };

    const forms = document.querySelectorAll('form');

    forms.forEach(form => {
        const inputs = form.querySelectorAll('input, textarea');

        inputs.forEach(input => {
            if (input.dataset.val === 'true') {
                input.addEventListener('input', () => {
                    switch (input.type) {
                        case 'text':
                            textValidator(input);
                            break;
                        case 'email':
                            emailValidator(input);
                            break;
                        // Add cases for other input types if needed
                    }
                });
            }
        });

        form.addEventListener('submit', (event) => {
            inputs.forEach(input => {
                if (input.dataset.val === 'true') {
                    switch (input.type) {
                        case 'text':
                            textValidator(input);
                            break;
                        case 'email':
                            emailValidator(input);
                            break;
                        // Add cases for other input types if needed
                    }
                }
            });

            const errors = form.querySelectorAll('.field-validation-error');
            if (errors.length > 0) {
                event.preventDefault();
            }
        });
    });
});