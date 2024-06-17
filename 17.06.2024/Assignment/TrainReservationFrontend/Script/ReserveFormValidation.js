const form = document.querySelector('#form')
const startingpoint = document.querySelector('#startingpoint');
const endingpoint = document.querySelector('#endingpoint');
// const traindate = document.querySelector('#traindate');
const userid = document.querySelector('#userid');
const trainid = document.querySelector('#trainid');
const seats = document.querySelector('#seats');
const classname = document.querySelector('#classname');

form.addEventListener('submit',(e)=>{
    
    if(!validateInputs()){
        e.preventDefault();
    }
})

function validateInputs(){
    const startingpointVal = startingpoint.value.trim()
    const  endingpointVal = endingpoint.value.trim();
    // const traindateVal = traindate.value;
    const useridVal = userid.value.trim();
    const trainidVal = trainid.value.trim();
    const seatsVal = seats.value.trim();
    const classnameVal = classname.value.trim();

    let success = true

    if(startingpointVal===''){
        success=false;
        setError(startingpoint,'StartingPoint is required')
    }
    else{
        setSuccess(startingpoint)
    }

    if(endingpointVal===''){
        success=false;
        setError(endingpoint,'EndingPoint is required')
    }
    else{
        setSuccess(endingpoint)
    }

    // const today = new Date();
    // if(traindateVal===''){
    //     success=false;
    //     setError(traindate,'TrainDate is Required')
    // }else if(traindateVal<today){
    //     success=false;
    //     setError(traindate,'Invalid Date Selection')
    // }else{
    //     console.log(today)
    //     console.log(traindate)
    //     setSuccess(traindate)
    // }

    if(useridVal === ''){
        success=false;
        setError(userid,'User ID is required')
    }else if(useridVal == 0){
        success=false;
        setError(userid,'User ID cannot be equal to zero')
    }else if(useridVal < 0){
        success=false;
        setError(userid,'User ID cannot be less to zero');
    }else{
        setSuccess(userid)
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


    const numbers = seatsVal.split(',').map(num => parseInt(num));
    if (seatsVal === '') {
        success= false;
        setError(seats,'Seats are Required')
    }else if(seatsVal != ''){
        if (numbers.some(num => isNaN(num))) {
            success= false;
            setError(seats,'Only Numbers are allowed')
        }
    }
    else{
        setSuccess(seats)
    }

    if(classnameVal === ''){
        success= false;
        setError(classname,'ClassName is required')
    }
    else if(classnameVal.length<3){
        success = false;
        setError(classnameVal,'ClassName must be atleast 3 characters long')
    }
    else{
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

const validateEmail = (email) => {
    return String(email)
      .toLowerCase()
      .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      );
  };