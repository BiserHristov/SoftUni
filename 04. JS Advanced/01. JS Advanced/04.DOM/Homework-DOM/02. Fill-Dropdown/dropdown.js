function addItem() {

    let textElement = document.querySelector('#newItemText');
    let valueElement = document.querySelector('#newItemValue');

    let optionElement = document.createElement('option');
    optionElement.setAttribute('value', valueElement.value);
    optionElement.innerHTML = textElement.value;

    let selectElement = document.querySelector('#menu');
    selectElement.appendChild(optionElement);
    textElement.value='';
    valueElement.value='';

}