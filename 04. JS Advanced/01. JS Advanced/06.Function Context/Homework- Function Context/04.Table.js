function solve() {
    Array.from(document.querySelectorAll('tbody tr')).forEach(tr => {
        tr.addEventListener('click', e => {

            Array.from(document.querySelectorAll('tbody tr')).forEach(row => {
                if (e.target.parentElement.isEqualNode(row)) {

                    if (row.style.backgroundColor == 'rgb(65, 63, 94)') {
                        row.style.backgroundColor = '';
                    }
                    else {
                        row.style.backgroundColor = 'rgb(65, 63, 94)'
                    }

                }
                else {
                    row.style.backgroundColor = '';

                }

            })

        })
    })
}
