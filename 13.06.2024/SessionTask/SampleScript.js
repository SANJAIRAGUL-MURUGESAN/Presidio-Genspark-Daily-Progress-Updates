const form = document.querySelector('#form')
const productid = document.querySelector('#productid');
const productname = document.querySelector('#productname');
const productprice = document.querySelector('#productprice');
const productquantity = document.querySelector('#productquantity');

form.addEventListener("submit",(e)=>{
    e.preventDefault(); 
    if(!validateInputs()){
        // e.preventDefault();
        return;
    }else{
        addTabeldate();
        alert('Product Added Successfully!')
    }
;
})

function validateInputs(){
    const productidVal = productid.value.trim()
    const productnameVal = productname.value.trim()
    const productpriceVal = productprice.value
    const productquantityVal = productquantity.value

    let success = true

    if(productidVal===''){
        success=false;
        setError(productid,'ProductID is required')
    }
    else{
        setSuccess(productid)
    }

    if(productnameVal===''){
        success=false;
        setError(productname,'ProductName is required')
    }
    else if(productnameVal.length < 3){
        success=false;
        setError(productname,'ProductName must be atleast 3 Characters')
    }
    else{
        setSuccess(productname)
    }

    if(productpriceVal===''){
        success=false;
        setError(productprice,'ProductPrice is required')
    }
    else if(productpriceVal == 0){
        success=false;
        setError(productprice,'ProductPrice Value cannot be zero')
    }
    else if(productpriceVal < 0){
        success=false;
        setError(productprice,'ProductPrice Value cannot be less than zero')
    }
    else{
        setSuccess(productprice)
    }

    if(productquantityVal===''){
        success=false;
        setError(productquantity,'Product Quantity is required')
    }
    else if(productquantityVal == 0){
        success=false;
        setError(productquantity,'Product Quanity cannot be zero')
    }
    else if(productquantityVal < 0){
        success=false;
        setError(productquantity,'Product Quanity cannot be less than zero')
    }
    else{
        setSuccess(productquantity)
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

function addTabeldate(){

    const table = document.querySelector('#table'); // Select the table element

    const productidVal = productid.value.trim()
    const productnameVal = productname.value.trim()
    const productpriceVal = productprice.value
    const productquantityVal = productquantity.value

    console.log(productidVal)

    // Create new table row
    const newRow = document.createElement("tr");

    // Create table data cells
    const productidCell = document.createElement("td");
    productidCell.innerText = productidVal;
    const productnameCell = document.createElement("td");
    productnameCell.innerText = productnameVal;
    const productpriceCell = document.createElement("td");
    productpriceCell.innerText = productpriceVal;
    const productquantityCell = document.createElement("td");
    productquantityCell.innerText = productquantityVal;

    // Append cells to row
    newRow.appendChild(productidCell);
    newRow.appendChild(productnameCell);
    newRow.appendChild(productpriceCell);
    newRow.appendChild(productquantityCell);

    // **Append the new row to the table**
    table.appendChild(newRow);
}
