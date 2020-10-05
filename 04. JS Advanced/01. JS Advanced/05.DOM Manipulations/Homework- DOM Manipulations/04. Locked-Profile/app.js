function lockedProfile() {
    [...document.querySelectorAll('button')].forEach(b => {
        b.addEventListener('click', (e) => {
            if (e.target.parentElement.querySelectorAll('input')[1].checked) {
                if ( e.target.textContent == 'Show more') {
                    e.target.previousElementSibling.style.display = 'block';
                e.target.textContent = 'Hide it'

                } else{
                    e.target.previousElementSibling.style.display = 'none';
                    e.target.textContent = 'Show more'
                }
                
            }
           
        })
    })
}
