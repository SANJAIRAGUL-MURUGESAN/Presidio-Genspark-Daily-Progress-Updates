const form = document.querySelector('#form')
const stationname = document.querySelector('#stationname');
const statename = document.querySelector('#statename');
const pincode = document.querySelector('#pincode');



form.addEventListener('submit',(e)=>{
    e.preventDefault();
    if(!validateInputs()){
        e.preventDefault();
    }
})

function validateInputs(){
    const stationnameVal = stationname.value.trim()
    const statenameVal = statename.value.trim()
    const pincodeVal = pincode.value.trim();

    let success = true

    if(stationnameVal===''){
        success=false;
        setError(stationname,'Station Name is required')
    }
    else if(stationnameVal.length<3){
        success = false;
        setError(stationname,'Station Name cannot be less than 3 characters long')
    }
    else{
        setSuccess(stationname)
    }



    if(statenameVal===''){
        success=false;
        setError(statename,'State Name is required')
    }
    else if(statenameVal.length<3){
        success = false;
        setError(statename,'State Name cannot be less than 3 characters long')
    }
    else{
        setSuccess(statename)
    }


    function validateNumber(input) {
        const numberDotRegex = /^\d+(\.\d*)?$/;
        return numberDotRegex.test(input);
    }

    if(pincodeVal===''){
        success=false;
        setError(pincode,'Pincode is required')
    }else if(!validateNumber(pincodeVal)){
        success= false;
        setError(pincode,'Only Numbers are allowed')
    }
    else{
        setSuccess(pincode)
    }
    return success;

}

//element - password, msg- pwd is reqd
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

