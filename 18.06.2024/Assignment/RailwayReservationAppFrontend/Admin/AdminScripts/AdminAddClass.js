const form = document.querySelector('#form')
const classname = document.querySelector('#classname');
const classprice = document.querySelector('#classprice');
const startingseatnumber = document.querySelector('#startingseatnumber');
const endingseatnumber = document.querySelector('#endingseatnumber');
const trainid = document.querySelector('#trainid');




form.addEventListener('submit',(e)=>{
    e.preventDefault();
    if(!validateInputs()){
        e.preventDefault();
    }
})

function validateInputs(){
    const classnameVal = classname.value.trim()
    const classpriceVal = classprice.value.trim()
    const startingseatnumberVal = startingseatnumber.value;
    const endingseatnumberVal = endingseatnumber.value;
    const trainidVal = trainid.value;

    let success = true

    if(classnameVal===''){
        success=false;
        setError(classname,'Class Name is required')
    }
    else if(classnameVal.length<3){
        success = false;
        setError(classname,'Class Name cannot be less than 3 characters long')
    }
    else{
        setSuccess(classname)
    }

    function validateNumber(input) {
        const numberDotRegex = /^\d+(\.\d*)?$/;
        return numberDotRegex.test(input);
    }

    if(classpriceVal===''){
        success=false;
        setError(classprice,'CLass Price is required')
    }else if(!validateNumber(classpriceVal)){
        success= false;
        setError(classprice,'Only Numbers are allowed')
    }
    else{
        setSuccess(classprice)
    }
    
    if(startingseatnumberVal === ''){
        success=false;
        setError(startingseatnumber,'Starting Seat Number is required')
    }else if(startingseatnumberVal < 0){
        success=false;
        setError(startingseatnumber,'Starting Seat Number cannot be less to zero');
    }else{
        setSuccess(startingseatnumber)
    }

    if(endingseatnumberVal === ''){
        success=false;
        setError(endingseatnumber,'Ending Seat Number is required')
    }else if(endingseatnumberVal < 0){
        success=false;
        setError(endingseatnumber,'Ending Seat Number cannot be less to zero');
    }else{
        setSuccess(endingseatnumber)
    }

    if(trainidVal === ''){
        success=false;
        setError(trainid,'Train ID is required')
    }else if(trainidVal == 0){
        success=false;
        setError(trainid,'Train ID cannot be equal to zero')
    }else if(trainidVal < 0){
        success=false;
        setError(trainid,'Train ID cannot be less to zero');
    }else{
        setSuccess(trainid)
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

