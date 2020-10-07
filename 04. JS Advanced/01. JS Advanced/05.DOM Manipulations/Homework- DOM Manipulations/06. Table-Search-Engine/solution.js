function solve() {
   document.querySelector('#searchBtn').addEventListener('click', (e)=>{
   
      let textElement= document.querySelector('#searchField');
      let text= textElement.value.toLowerCase();
      Array.from(document.querySelector('tbody').querySelectorAll('tr')).forEach(tr=>{
         if (tr.classList.contains('select')) {
            tr.classList.remove('select')
         }
      })
      textElement.value='';
      Array.from(document.querySelector('tbody').querySelectorAll('td')).forEach(td=>{
         if (td.textContent.toLowerCase().indexOf(text)>=0) {
            td.parentElement.classList.add('select');
         }
      })
   
   })
   }
   