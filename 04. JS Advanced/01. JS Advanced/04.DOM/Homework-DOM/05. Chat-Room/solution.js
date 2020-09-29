function solve() {

   let sendBtn = document.querySelector('#send')

   sendBtn.addEventListener('click', function () {

      let textareaElement = document.querySelector('#chat_input')
      let newMessageDiv= document.createElement('div');
      newMessageDiv.setAttribute('class', 'message my-message');
      newMessageDiv.innerHTML=textareaElement.value;
      document.querySelector('#chat_messages').appendChild(newMessageDiv)
      textareaElement.value='';
   })
}


