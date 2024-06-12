const isValidLength = (string)=>{
    if(string.length > 3){
        return true;
    }
    return false;
}

var ResultArray=[];
const stringFunction = (StringArray, validCheckFucnction)=>{
    for(let value of StringArray){
        if(validCheckFucnction(value) == true){
            ResultArray.push(value)
        }
    }
    return () => console.log(ResultArray);
}

let StringArray = ["Mam", "Presidio", "Genspark", "Prograd", "Abc"];
// console.log(stringFunction(StringArray, isValidLength));
let result = stringFunction(StringArray, isValidLength);
// result()

//reduce
// let arrayOfNumbers=[1,2,3,4,5]
// let sumOfArrayElements=arrayOfNumbers.reduce((sum,value)=>{
// return sum+value
// })
// console.log(sumOfArrayElements)

//foreach
// let arrayOfNumbers2=[22,45,99,3,8,44]
// arrayOfNumbers2.forEach(num=>{console.log(num)})

// //sort
let arrayOfNumbers3=[22,45,99,3,8,44]
arrayOfNumbers3.sort((numOne,numTwo)=>numOne-numTwo)
console.log(arrayOfNumbers3)