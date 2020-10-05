function create(words) {
   words.forEach(word => {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.style.display = 'none';
      p.textContent = word

      div.appendChild(p);
      document.querySelector('#content').appendChild(div);
      div.addEventListener('click', (e) => {
         e.target.children[0].style='block'
      })
   });

}