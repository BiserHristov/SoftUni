function solution() {
    let sections=document.getElementsByClassName('card');
  
    let input=sections[0].querySelector('div>input');
   
    let listOfGifts=sections[1].querySelector('ul');
    let sentGifts=sections[2].querySelector('ul');
    let discardedGifts=sections[3].querySelector('ul');
  
    let addButton=document.querySelector('button').addEventListener('click',(e)=>{
      let sendButton=document.createElement('button');
      sendButton.setAttribute('id','sendButton');
      sendButton.textContent='Send';
      sendButton.addEventListener('click',()=>{
          discardButton.remove();
          sendButton.remove();
         sentGifts.appendChild(li);
         
  
      })
      let discardButton=document.createElement('button');
      discardButton.textContent='Discard';
      discardButton.setAttribute('id','discardButton');
      discardButton.addEventListener('click',()=>{
          discardButton.remove();
          sendButton.remove();
         discardedGifts.appendChild(li);
      })
      
  
  
        let li=document.createElement('li');
        li.classList.add('gift');
        li.textContent=input.value;
        li.appendChild(sendButton);
        li.appendChild(discardButton);
        listOfGifts.appendChild(li);
        Array.from(listOfGifts.children).sort((a,b)=>a.textContent.localeCompare(b.textContent)).forEach(li=>listOfGifts.appendChild(li));
        input.value='';
  
  
    })
  }