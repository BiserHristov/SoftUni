function solve() {
    let inputsPerRow = Array.from(document.querySelectorAll('tbody tr'))[0].childElementCount;
    let rows = Array.from(document.querySelectorAll('tbody tr')).length;


    //Quick Check Button
    document.querySelectorAll('button')[0].addEventListener('click', ev => {

        let isValid = true;

        Array.from(document.querySelectorAll('tbody tr')).forEach(tr => {
            let numbers = new Set();
            Array.from(tr.querySelectorAll('input')).forEach(i => {
                numbers.add(Number(i.value))
            })

            if (numbers.size != Array.from(tr.querySelectorAll('input')).length) {
                isValid = false;
            }
        })


        for (let col = 0; col < inputsPerRow; col++) {

            let numbers = new Set();

            for (let row = 0; row < rows; row++) {
                let number = Array.from(document.querySelectorAll('tbody tr'))[row].children[col].children[0].value;
                numbers.add(Number(number));
            }

            if (numbers.size != rows) {
                isValid = false;
            }

        }


        if (isValid) {
            document.querySelector('table').style.border = "2px solid green";
            document.querySelector('#check').children[0].textContent = "You solve it! Congratulations!";
            document.querySelector('#check').children[0].style.color = 'green';
        } else {
            document.querySelector('table').style.border = "2px solid red";
            document.querySelector('#check').children[0].textContent = "NOP! You are not done yet...";
            document.querySelector('#check').children[0].style.color = 'red';
        }

    })



    //Clear button
    document.querySelectorAll('button')[1].addEventListener('click', ev => {

        Array.from(document.querySelectorAll('tbody tr')).forEach(tr => {

            Array.from(tr.querySelectorAll('input')).forEach(i => {
                i.value = '';
            })
        })

        document.querySelector('table').removeAttribute('border');
        document.querySelector('#check').children[0].textContent = '';
        document.querySelector('#check').removeAttribute('color');



    })


}


