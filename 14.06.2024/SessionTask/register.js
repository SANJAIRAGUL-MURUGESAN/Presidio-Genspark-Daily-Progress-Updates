const browserInput = document.getElementById("browser");
const browserDatalist = document.getElementById("browsers");
const otherInputContainer = document.getElementById("otherInputContainer");


browserInput.addEventListener("input", function(event) {
    const newValue = event.target.value.trim();
    if (newValue === "Other") {
        const otherInput = document.createElement("input");
        otherInput.type = "text";
        otherInput.placeholder = "Enter other Profession";
        otherInput.id = "otherInput";
        otherInput.className = "form-control"
        otherInputContainer.innerHTML = "";
        otherInputContainer.appendChild(otherInput);
      } else {
        otherInputContainer.innerHTML = "";
      }
});


// Function to calculate age
function calculateAge(dob) {
  const today = new Date();
  const birthDate = new Date(dob);
  let age = today.getFullYear() - birthDate.getFullYear();
  const month = today.getMonth() - birthDate.getMonth();
  if (month < 0 || (month === 0 && today.getDate() < birthDate.getDate())) {
    age--;
  }
  return age;
}

// Event listener for date of birth input
document.getElementById('dob').addEventListener('change', function() {
  const dob = this.value;
  const age = calculateAge(dob);
  document.getElementById('age').value = age;
});


document.getElementById("registrationForm").addEventListener("submit", function(event) {
    event.preventDefault();

    // To Validate form
    const errors = validateForm();
    
    // To Display errors
    const result = displayErrors(errors);

    
    // To Get the value from the browser input or other input box
    const newValue = document.getElementById("otherInput") ? document.getElementById("otherInput").value.trim() : browserInput.value.trim();
  
    // To Add to datalist if not empty
    if (newValue !== "") {
      const options = Array.from(browserDatalist.options);
      const alreadyExists = options.some(option => option.value === newValue);
  
      // If the value is not already in the datalist, add it
      if (!alreadyExists) {
        const newOption = document.createElement("option");
        newOption.value = newValue;
        browserDatalist.appendChild(newOption);
      }
    }

    if(result){
        alert('Registration Successful!')
    }
    // Reset form
    event.target.reset();

  });

  function validateForm() {
    const errors = [];
    const nameError = validateName();
    if (nameError) {
      errors.push(nameError);
    }
    const phoneError = validatePhone();
    if (phoneError) {
      errors.push(phoneError);
    }
    const dobError = validateDOB();
    if (dobError) {
      errors.push(dobError);
    }
    const emailError = validateEmail();
    if (emailError) {
      errors.push(emailError);
    }
    const genderError = validateGender();
    if (genderError) {
      errors.push(genderError);
    }
    const qualificationError = validateQualification();
    if(qualificationError){
        errors.push(qualificationError);
    }
    const professionError = validateProfession();
    if(professionError){
        errors.push(professionError);
    }
    return errors;
  }

  function validateName() {
    const name = document.getElementById('name').value.trim();
    if (name === '') {
      return 'Name is required';
    }else if(name.length <= 2){
        return 'Name must be atleast three characters long'
    }
    return '';
  }
  
  function validatePhone() {
    const phone = document.getElementById('phone').value.trim();
    const phoneRegex = /^\d{10}$/;
    const phoneRegex2 = /^[0-9]+$/;
    if (!phoneRegex2.test(phone)) {
      return 'Phone number must contain only numbers';
    }
    if (!phoneRegex.test(phone)) {
      return 'Phone number must be 10 digits';
    }
    return '';
  }
  
  function validateDOB() {
    const dobInput = document.getElementById('dob');
    const dob = new Date(dobInput.value);
    const today = new Date();
    if (dob > today) {
      return 'Date of Birth cannot be in the future';
    }
    return '';
  }
  
  function validateEmail() {
    const email = document.getElementById('email').value.trim();
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      return 'Invalid email address';
    }
    return '';
  }

  function validateGender() {
    const maleRadio = document.getElementById('male');
    const femaleRadio = document.getElementById('female');
    if (!maleRadio.checked && !femaleRadio.checked) {
      return 'Please select a gender';
    }
    return '';
  }

  function validateQualification() {
    const checkboxes = document.querySelectorAll('input[name="qualification"]:checked');
    if (checkboxes.length === 0) {
      return 'Select at least one qualification';
    }
    return '';
  }

  function validateProfession() {
    const newValue = document.getElementById("otherInput") ? document.getElementById("otherInput").value.trim() : browserInput.value.trim();
    if (newValue === '') {
      return 'Select a profession or enter a custom one';
    }
    return '';
  }

    function displayErrors(errors) {
        const errorSummary = document.getElementById('errorSummary');
        errorSummary.innerHTML = '';
        if (errors.length > 0){ 
            errors.forEach(error => {
                const errorDiv = document.createElement('div');
                errorDiv.textContent = error;
                errorSummary.appendChild(errorDiv);
            });
            return false;
        }
            return true; 
    }

    function outFunction(){
        var name = document.getElementById('name')
        if (!name.value) {
            name.classList.add("errors");
            name.classList.remove("corrects");
        }
        else {
            name.classList.remove("errors");
            name.classList.add("corrects");
        }
    }

    function outphoneFunction(){
        var phone = document.getElementById('phone')
        if (!phone.value) {
            phone.classList.add("errors");
            phone.classList.remove("corrects");
        }
        else {
            phone.classList.remove("errors");
            phone.classList.add("corrects");
        }
    }

    function outdobFunction(){
        var dob = document.getElementById('dob')
        if (!dob.value) {
            dob.classList.add("errors");
            dob.classList.remove("corrects");
        }
        else {
            dob.classList.remove("errors");
            dob.classList.add("corrects");
        }
    }

    function outemailFunction(){
        var email = document.getElementById('email')
        if (!email.value) {
            email.classList.add("errors");
            email.classList.remove("corrects");
        }
        else {
            email.classList.remove("errors");
            email.classList.add("corrects");
        }
    }


    function outprofFunction(){
        var browser = document.getElementById('browser')
        if (!browser.value) {
            browser.classList.add("errors");
            browser.classList.remove("corrects");
        }
        else {
            browser.classList.remove("errors");
            browser.classList.add("corrects");
        }
    }