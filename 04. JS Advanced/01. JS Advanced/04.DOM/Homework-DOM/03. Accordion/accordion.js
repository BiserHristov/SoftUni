function toggle() {
let divElement= document.querySelector('#extra');
divElement.style.display= divElement.style.display=='block'? 'none': 'block';
let buttonSpan= document.querySelector('.button')
buttonSpan.innerHTML= buttonSpan.innerHTML=='More'? 'Less': 'More';

}