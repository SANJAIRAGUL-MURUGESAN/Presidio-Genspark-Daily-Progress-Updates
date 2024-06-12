const form = document.querySelector('#form')
const trainid = document.querySelector('#trainid');


form.addEventListener('submit',(e)=>{
    
    if(!validateInputs()){
        e.preventDefault();
    }
})

function validateInputs(){

    const trainidVal = trainid.value.trim();

    let success = true

    if(trainidVal === ''){
        success= false;
        setError(trainid,'TrainId is required')
    }
    else if(trainidVal.length>10){
        success = false;
        setError(trainid,'TrainId must be less than 10 characters long')
    }
    else{
        setSuccess(trainid)
    }

    return success;
}

function setError(element,message){
    const inputGroup = element.parentElement;
    const errorElement = inputGroup.querySelector('.error')

    errorElement.innerText = message;
    inputGroup.classList.add('error')
    inputGroup.classList.remove('success')
}

function setSuccess(element){
    const inputGroup = element.parentElement;
    const errorElement = inputGroup.querySelector('.error')

    errorElement.innerText = '';
    inputGroup.classList.add('success')
    inputGroup.classList.remove('error')
}