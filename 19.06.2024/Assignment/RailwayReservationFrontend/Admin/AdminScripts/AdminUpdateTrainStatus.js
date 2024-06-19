const form = document.querySelector('#form')
const trainid = document.querySelector('#trainid');

async function updateTrainStatus(){
    fetch('http://localhost:5062/api/Admin/UpdateTrainStatusAsCompleted', {
        method: 'PUT',
        headers: {
            'Authorization': 'Bearer '+localStorage.getItem('token'),
            'Content-Type': 'application/json',
         },
        body: JSON.stringify(trainid.value)
    })
    .then(async res => {
        if (!res.ok) {
            const data = await res.json();
            console.log(data.errorCode)
            alert(data.message);
        }else{
            alert('Hey Admin, Train Status Updated Successfully!');
        }
    })
    .catch(error => {
        alert(error);
    });
}



form.addEventListener('submit',(e)=>{
    e.preventDefault();
    if(!validateInputs()){
        return
    }else{
        updateTrainStatus()
    }
})

function validateInputs(){

    const trainidVal = trainid.value

    let success = true

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

