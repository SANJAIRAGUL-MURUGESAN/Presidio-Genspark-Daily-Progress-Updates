const form = document.querySelector('#form')
const cancelreason = document.querySelector('#cancelreason');
const seatnumber = document.querySelector('#seatnumber');
const refundamount = document.querySelector('#refundamount');
const userid = document.querySelector('#userid');
const reservationid = document.querySelector('#reservationid');

form.addEventListener('submit',(e)=>{
    
    if(!validateInputs()){
        e.preventDefault();
    }
})

function validateInputs(){

    const cancelreasonVal = cancelreason.value.trim()
    const seatnumberVal = seatnumber.value
    const refundamountVal = refundamount.value.trim()
    const useridVal = userid.value.trim();
    const reservationidVal = reservationid.value.trim()


    let success = true

    if(cancelreasonVal===''){
        success=false;
        setError(cancelreason,'Cancelling Reason is required')
    }
    else if(cancelreasonVal.length < 5){
        success=false;
        setError(cancelreason,'Cancelling Reason must be atleast 3 characters long ')
    }
    else{
        setSuccess(cancelreason)
    }

    if(seatnumberVal == 0){
        success=false;
        setError(seatnumber,'Seat Number cannot be 0')
    }
    else if(seatnumberVal < 0){
        success=false;
        setError(seatnumber,'Seat Number cannot be less than Zero')
    }else{
        setSuccess(seatnumber)
    }

    if(refundamountVal == 0){
        success=false;
        setError(refundamount,'Refund Amount cannot be Zero')
    }
    else if(refundamountVal < 0){
        success=false;
        setError(refundamount,'Refund Amount cannot be less than Zero')
    }else{
        setSuccess(refundamount)
    }

    if(useridVal === ''){
        success= false;
        setError(userid,'UserId is required')
    }
    else if(useridVal.length>10){
        success = false;
        setError(userid,'UserId must be less than 10 characters long')
    }
    else{
        setSuccess(userid)
    }

    if(reservationidVal === ''){
        success= false;
        setError(reservationid,'ReservationId is required')
    }
    else if(reservationidVal.length>10){
        success = false;
        setError(reservationid,'ReservationId must be less than 10 characters long')
    }
    else{
        setSuccess(reservationidVal)
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