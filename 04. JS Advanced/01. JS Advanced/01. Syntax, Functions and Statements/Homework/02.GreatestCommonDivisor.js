function GetGCD(firstNum, secondNum) {
    let minNumber = Math.min(firstNum, secondNum);
    
    for (let index = minNumber; index > 0; index--) {
        if (firstNum % index == 0 &&
            secondNum % index == 0) {
            console.log(index);
            break;
        }

    }
}

GetGCD(15, 5);
GetGCD(2154, 458);