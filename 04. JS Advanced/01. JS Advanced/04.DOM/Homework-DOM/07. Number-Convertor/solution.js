function solve() {
    let toBinOptionElement = document.createElement('option');
    toBinOptionElement.setAttribute('value', 'binary');
    toBinOptionElement.innerHTML = 'Binary';

    let toHexOptionElement = document.createElement('option');
    toHexOptionElement.setAttribute('value', 'hexadecimal');
    toHexOptionElement.innerHTML = 'Hexadecimal';

    document.querySelector('#selectMenuTo').appendChild(toBinOptionElement);
    document.querySelector('#selectMenuTo').appendChild(toHexOptionElement);
    let element = document.querySelector('[value=binary]');
    element.setAttribute('selected', 'selected');

    let convertBtn = document.querySelector('button');
    let inputElement = document.querySelector('#input');
    let resultElement = document.querySelector('#result')

    convertBtn.addEventListener('click', function () {
        let inputNum = Number(inputElement.value);
        if (document.querySelector('#selectMenuTo').value == 'binary') {
            resultElement.value = parseInt(inputNum.toString(2));
        }
        else{
            resultElement.value = inputNum.toString(16).toUpperCase();
        }
    })

}