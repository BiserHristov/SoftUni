function solve() {
    let toBinOptionElement = document.createElement('option');
    toBinOptionElement.setAttribute('value', 'binary');
    toBinOptionElement.innerHTML = 'Binary';

    let toHexOptionElement = document.createElement('option');
    toHexOptionElement.setAttribute('value', 'hexadecimal');
    toHexOptionElement.innerHTML = 'Hexadecimal';

    //  document.querySelector('#selectMenuTo').firstChild().setAttribute("selected value",'binary' );
    //  document.querySelector('#selectMenuTo').firstChild.innerHTML='Binary';
    document.querySelector('#selectMenuTo').appendChild(toBinOptionElement);
    document.querySelector('#selectMenuTo').appendChild(toHexOptionElement);
    let element = document.querySelector('[value=binary]');
    element.setAttribute('selected', 'selected');

    let convertBtn = document.querySelector('button');
    let inputElement = document.querySelector('#input');
    // let inputNum= Number(inputElement.value);
    let resultElement= document.querySelector('#result')

    convertBtn.addEventListener('click', function () {
        let inputNum= Number(inputElement.value);
        if (document.querySelector('#selectMenuTo').value == 'binary') {
            let bin = 0;
            let rem, i = 1, step = 1;
            while (inputNum != 0) {
                rem = inputNum % 2;
             
                inputNum = parseInt(inputNum / 2);
                bin = bin + rem * i;
                i = i * 10;
            }
            resultElement.value=bin;

        }
    })

}