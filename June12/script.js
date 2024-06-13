// function checkingEvenNumbers(num)
// {
//     return num%2==0//boolean
// }


// function filteringEvenNumbers(numbers,callbackFunc)
// {
//     let numberArray=[]
//     for(let value of numbers)
//     {
//         if(callbackFunc(value))
//             numberArray.push(value)
//     }
//     return ()=>console.log(numberArray)
// }

// let arrayOfNumbers=[22,45,99,3,8,44]
// // console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))
// let result=filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers)
// result()

//reduce
// let arrayOfNumbers=[1,2,3,4,5]
// let sumOfArrayElements=arrayOfNumbers.reduce((sum,value)=>{
// return sum+value
// })
// console.log(sumOfArrayElements)

//foreach
// let arrayOfNumbers=[22,45,99,3,8,44]
// arrayOfNumbers.forEach(num=>{console.log(num)})

//sort
let arrayOfNumbers=[22,45,99,3,8,44]
arrayOfNumbers.sort((numOne,numTwo)=>numOne-numTwo)
console.log(arrayOfNumbers)

 //changing the style of an element
 const changeStyle=()=>{
    document.getElementById('demo').style.color='pink'
}


//creating and adding element
// let element=document.createElement('div')
// element.innerHTML='<h4>hey we are still learning</h4>'
// document.body.appendChild(element)


//adding element ot existing element
// let existingDiv=document.getElementById('divId')
// let element=document.createElement('div')
// element.innerHTML='<h4>hey we are still learning</h4>'
// existingDiv.appendChild(element)


//removing the element

const removeElement=()=>{
    let existingDivWithId=document.getElementById('divId')
    document.body.removeChild(existingDivWithId)
}