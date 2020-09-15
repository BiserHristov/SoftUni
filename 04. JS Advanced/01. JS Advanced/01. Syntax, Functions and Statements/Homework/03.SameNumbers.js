function SameNumbers(number) {
    let numAsStr = number.toString();
    let areEqual = true;
    let firstDigit = numAsStr[0];
    let sum = Number(firstDigit);

    for (let index = 1; index < numAsStr.length; index++) {
        if (firstDigit != numAsStr[index]) {
            areEqual = false;
        }

        sum += Number(numAsStr[index]);
    }

    console.log(areEqual);
    console.log(sum);

}

SameNumbers(2222222);
SameNumbers(1234);