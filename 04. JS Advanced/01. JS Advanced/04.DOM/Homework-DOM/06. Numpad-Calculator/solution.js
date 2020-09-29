function solve() {
    let btnsDiv = document.querySelector('.keys');
    let clrBtn = document.querySelector('.clear');
    let expElement = document.querySelector('#expressionOutput');
    let resultElement = document.querySelector('#resultOutput');

    clrBtn.addEventListener('click', function () {
        expElement.innerHTML = '';
        resultElement.innerHTML = '';
    })


    btnsDiv.addEventListener('click', function (el) {
        let numberAsStr = el.target.value;

        if (numberAsStr == '=') {

            let [firstNum, operand, secondNum] = expElement.innerHTML.split(' ');
            firstNum = parseFloat(firstNum);
            secondNum = parseFloat(secondNum);

            if (isNaN(firstNum) || isNaN(secondNum)) {
                resultElement.innerHTML = 'NaN';
            }
            else {

                if (operand == '+') {
                    resultElement.innerHTML = firstNum + secondNum;
                } else if (operand == '-') {
                    resultElement.innerHTML = firstNum - secondNum;
                } else if (operand == '*') {
                    resultElement.innerHTML = firstNum * secondNum;
                } else if (operand == '/') {
                    resultElement.innerHTML = firstNum / secondNum;
                }
            }


        }


     
        if (!isNaN(numberAsStr) || numberAsStr != '=') { 
            if (numberAsStr == '+' ||
                numberAsStr == '-' ||
                numberAsStr == '/' ||
                numberAsStr == '*') {
                expElement.innerHTML += ` ${numberAsStr} `;
                operand = numberAsStr;
             
            } else {
                expElement.innerHTML += numberAsStr;
            }


        }

    })
}