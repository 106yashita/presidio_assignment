// JavaScript source code

document.addEventListener("DOMContentLoaded", function () {
    const names=["John"];
    const form = document.getElementById("registration-form");
    const nameInput = document.getElementById("name");
    const phoneInput = document.getElementById("phone");
    const dobInput = document.getElementById("dob");
    const emailInput = document.getElementById("email");
    const ageInput = document.getElementById("age");
    const genderInputs = document.querySelectorAll('input[name="gender"]');
    const qualificationInputs = document.querySelectorAll('input[name="qualification"]');
    const professionInput = document.getElementById("profession");

    form.addEventListener("submit", function (event) {
        event.preventDefault();
        validateForm();
    });

    nameInput.addEventListener("blur", function () {
        validateName();
    });

    phoneInput.addEventListener("blur", function () {
        validatePhone();
    });

    dobInput.addEventListener("blur", function () {
        validateDob();
    });

    emailInput.addEventListener("blur", function () {
        validateEmail();
    });

    function validateForm() {
        resetErrors();
        let isValid = true;

        if (!validateName()) isValid = false;
        if (!validatePhone()) isValid = false;
        if (!validateDob()) isValid = false;
        if (!validateEmail()) isValid = false;
        if (!validateGender()) isValid = false;
        if (!validateQualification()) isValid = false;
        if (!validateProfession()) isValid = false;

        if (!isValid) {
            const errorMessage = document.createElement("div");
            errorMessage.textContent = "Please fix the errors before submitting.";
            errorMessage.classList.add("text-danger");
            form.appendChild(errorMessage);
        } else {
            updatePredefinedList();
            //form.submit();
            form.reset();
            ageInput.value = ""; 
        }
    }

    function validateName() {
        const name = nameInput.value.trim();
        if (name === "") {
            displayError("name-error", "Name is required.");
            return false;
        }
        return true;
    }

    function validatePhone() {
        const phone = phoneInput.value.trim();
        if (phone === "") {
            displayError("phone-error", "Phone is required.");
            return false;
        }
        return true;
    }

    function validateDob() {
        const dob = dobInput.value;
        if (dob === "") {
            displayError("dob-error", "Date of Birth is required.");
            return false;
        }
        return true;
    }

    function validateEmail() {
        const email = emailInput.value.trim();
        if (email === "") {
            displayError("email-error", "Email is required.");
            return false;
        }
        // Basic email validation
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            displayError("email-error", "Invalid email format.");
            return false;
        }
        return true;
    }

    function validateGender() {
        const checkedGender = Array.from(genderInputs).some(input => input.checked);
        if (!checkedGender) {
            displayError("gender-error", "Gender is required.");
            return false;
        }
        return true;
    }

    function validateQualification() {
        const checkedQualifications = Array.from(qualificationInputs).some(input => input.checked);
        if (!checkedQualifications) {
            displayError("qualification-error", "At least one qualification is required.");
            return false;
        }
        return true;
    }

    function validateProfession() {
        const profession = professionInput.value.trim();
        if (profession === "") {
            displayError("profession-error", "Profession is required.");
            return false;
        }
        return true;
    }

    function resetErrors() {
        const errorMessages = document.querySelectorAll(".error-message");
        errorMessages.forEach(message => message.textContent = "");
        const formErrors = document.querySelectorAll(".text-danger");
        formErrors.forEach(error => error.remove());
    }

    function displayError(id, message) {
        const errorElement = document.getElementById(id);
        errorElement.textContent = message;
    }

    // Calculate age based on Date of Birth
    dobInput.addEventListener("change", function () {
        const dob = new Date(dobInput.value);
        const today = new Date();
        const age = today.getFullYear() - dob.getFullYear();
        ageInput.value = age;
    });

    function updatePredefinedList() {
        const name = nameInput.value.trim();
        if (name && !names.includes(name)) {
            names.push(name);
            console.log(`New name added: ${name}`);
            console.log(`Updated predefined name list: ${names}`);
        }
    }
});
