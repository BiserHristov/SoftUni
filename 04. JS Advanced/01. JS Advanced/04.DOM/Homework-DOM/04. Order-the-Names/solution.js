function solve() {

    let addBtn = document.querySelector('button');

    addBtn.addEventListener('click', function () {
        let inputElement = document.querySelector('input');
        let inputValue = inputElement.value.charAt(0).toUpperCase() + inputElement.value.slice(1).toLowerCase();
        let firstLetterPosition = inputValue.charCodeAt(0) - 64;
        let liElements = document.querySelector('ol').children;
        var liElement = liElements.item(firstLetterPosition - 1);
        
        if (liElement.innerHTML.length != 0) {
            liElement.innerHTML += ', '
        }

        liElement.innerHTML += inputValue;
        inputElement.value = '';
    })



}