const form = document.querySelector('#form')
const userid = document.querySelector('#userid');
const password = document.querySelector('#password');


function userlogin(){
            fetch('http://localhost:5062/api/Admin/AdminLogin', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                 },
                body: JSON.stringify({
                    "id": userid.value.trim(),
                    "password": password.value.trim()
                })
            })
            .then(async res => {
                const data = await res.json();
                console.log(data)
                if (!res.ok) {
                    console.log(data.errorCode)
                    alert(data.message);
                }else{
                    localStorage.setItem('token',data.token);
                    alert('Hey User, Login Successful!');
                }
            })
            .catch(error => {
                alert(error);
            });
}


form.addEventListener('submit',async(e)=>{
    e.preventDefault();
    if(!validateInputs()){
        return;
    }else{
        userlogin();
    }
})

function validateInputs(){

    const useridVal = userid.value.trim()
    const passwordVal = password.value.trim();

    let success = true

    if(useridVal===''){
        success=false;
        setError(userid,'UserId is required')
    }
    else{
        setSuccess(userid)
    }

    if(passwordVal === ''){
        success= false;
        setError(password,'Password is required')
    }
    else if(passwordVal.length<8){
        success = false;
        setError(password,'Password must be atleast 8 characters long')
    }
    else{
        setSuccess(password)
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

