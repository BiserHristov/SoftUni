function subtract() {
    let firstElement = document.querySelector('#firstNumber').value;
    let secondElement = document.querySelector('#secondNumber').value;
    let result=document.querySelector('#result');
    result.innerHTML=Number(firstElement) - Number(secondElement);
}