function solve() {
  let correctAnswers = 0;
  [...document.querySelectorAll('section')].forEach(s => {
    [...s.querySelectorAll('.answer-text')].forEach(p => {
      p.addEventListener('click', (e) => {
        if (e.target.textContent == 'onclick' ||
          e.target.textContent == "JSON.stringify()" ||
          e.target.textContent == "A programming API for HTML and XML documents") {
          correctAnswers++;
        }
        s.style.display='none';

        if (s.nextElementSibling.tagName.toLowerCase() == 'section') {
          if (s.nextElementSibling.style.display == '') {
            s.nextElementSibling.style.display = 'block'
          }
        } else {
          document.querySelector("#results").style.display = "block";
          if (correctAnswers == 3) {

            document.querySelector('.results-inner h1').textContent = "You are recognized as top JavaScript fan!";

          }
          else {
            document.querySelector('.results-inner h1').textContent = `You have ${correctAnswers} right answers`;
          }
        }

      })
    })
  });

}