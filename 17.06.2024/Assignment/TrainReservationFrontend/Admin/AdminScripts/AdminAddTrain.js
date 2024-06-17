const form = document.querySelector('#form')
const trainname = document.querySelector('#trainname');
const trainnumber = document.querySelector('#trainnumber');
const startingpoint = document.querySelector('#startingpoint');
const endingpoint = document.querySelector('#endingpoint');
const starttime = document.querySelector('#trainstarttime');
const endtime = document.querySelector('#trainendtime');
const totalseats = document.querySelector('#totalseats');
const priceperkm = document.querySelector('#priceperkm');
const trainstatus = document.querySelector('#trainstatus');


form.addEventListener('submit',(e)=>{
    e.preventDefault();
    if(!validateInputs()){
        e.preventDefault();
    }
})

function validateInputs(){
    const trainnameVal = trainname.value.trim()
    const trainnumberVal = trainnumber.value
    const startingpointVal = startingpoint.value.trim();
    const endingpointVal = endingpoint.value.trim();
    const starttimeVal = starttime.value.trim();
    const endtimeVal = endtime.value.trim();
    const totalseatsVal = totalseats.value;
    const priceperkmVal = priceperkm.value.trim();
    const trainstatusVal = trainstatus.value.trim();

    let success = true

    if(trainnameVal===''){
        success=false;
        setError(trainname,'TrainName is required')
    }
    else if(trainnameVal.length<3){
        success = false;
        setError(trainname,'Train Name cannot be less than 3 characters long')
    }
    else{
        setSuccess(trainname)
    }

    if(trainnumberVal === ''){
        success=false;
        setError(trainnumber,'TrainNumber is required')
    }else if(trainnumberVal == 0){
        success=false;
        setError(trainnumber,'TrainNumber cannot be equal to zero')
    }else if(trainnumberVal < 0){
        success=false;
        setError(trainnumber,'TrainNumber cannot be less to zero');
    }else{
        setSuccess(trainnumber)
    }

    if(startingpointVal===''){
        success=false;
        setError(startingpoint,'StartingPoint is required')
    }
    else if(startingpointVal.length<3){
        success = false;
        setError(startingpoint,'Starting Point cannot be less than 3 characters long')
    }
    else{
        setSuccess(startingpoint)
    }

    if(endingpointVal===''){
        success=false;
        setError(endingpoint,'EndingPoint is required')
    }
    else if(endingpointVal.length<3){
        success = false;
        setError(endingpoint,'Ending Point cannot be less than 3 characters long')
    }
    else{
        setSuccess(endingpoint)
    }

    const pattern = /^\d{4}-\d{2}-\d{2} \d{2}:\d{2} (?:[AP]M)$/i;
    // 2023-11-19 03:22 PM
    if (pattern.test(starttimeVal)) {
        setSuccess(starttime)
    }
    else {
        success = false;
        setError(starttime,'Invalid Start Time format')
    }

    if (pattern.test(endtimeVal)) {
        setSuccess(endtime)
    }
    else {
        success = false;
        setError(endtime,'Invalid End Time format')
    }

    if(totalseatsVal === ''){
        success=false;
        setError(totalseats,'TotalSeats is required')
    }else if(totalseatsVal == 0){
        success=false;
        setError(totalseats,'TotalSeats cannot be equal to zero')
    }else if(totalseatsVal < 0){
        success=false;
        setError(totalseats,'TotalSeats cannot be less to zero');
    }else{
        setSuccess(totalseats)
    }

    function validateNumber(input) {
        const numberDotRegex = /^\d+(\.\d*)?$/;
        return numberDotRegex.test(input);
    }

    if(priceperkmVal===''){
        success=false;
        setError(priceperkm,'PricePerKm is required')
    }else if(!validateNumber(priceperkmVal)){
        success= false;
        setError(priceperkm,'Only Numbers are allowed')
    }
    else{
        setSuccess(priceperkm)
    }

    if(trainstatusVal===''){
        success=false;
        setError(trainstatus,'TrainStatus is required')
    }
    else if(trainstatusVal.length<3){
        success = false;
        setError(trainstatus,'Train Status cannot be less than 3 characters long')
    }
    else{
        setSuccess(trainstatus)
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

