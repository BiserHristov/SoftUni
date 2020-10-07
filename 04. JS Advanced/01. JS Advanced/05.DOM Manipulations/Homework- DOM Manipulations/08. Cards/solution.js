function solve() {
   Array.from(document.querySelectorAll('img')).forEach(i =>
      i.addEventListener('click', e => {
         e.target.setAttribute('src', 'images/whiteCard.jpg');
         let resultDiv = document.querySelector('#result');
         let player = -1;

         player = e.target.parentElement.getAttribute("id") == 'player1Div' ? 0 : 2;

         resultDiv.children[player].textContent = e.target.name;

         if (Array.from(resultDiv.children).every(el => el.textContent != '')) {
            if (Number(resultDiv.children[0].textContent) > Number(resultDiv.children[2].textContent)) {
               document.querySelector('#player1Div').querySelector(`[name=\"${resultDiv.children[0].textContent}\"]`).style.border = "2px solid green";
               document.querySelector('#player2Div').querySelector(`[name=\"${resultDiv.children[2].textContent}\"]`).style.border = "2px solid red";
            } else {
               document.querySelector('#player1Div').querySelector(`[name=\"${resultDiv.children[0].textContent}\"]`).style.border = "2px solid red";
               document.querySelector('#player2Div').querySelector(`[name=\"${resultDiv.children[2].textContent}\"]`).style.border = "2px solid green";
            }

            let historyDiv = document.querySelector('#history');
            
            historyDiv.textContent += "[" + resultDiv.children[0].textContent + " vs " + resultDiv.children[2].textContent + "] ";
            resultDiv.children[0].textContent='';
            resultDiv.children[2].textContent='';
         }
      })
   )
}
