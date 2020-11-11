let idElement = document.querySelector('#id')
let firstNameElement = document.querySelector('#FName')
let lastNameElement = document.querySelector('#LName')
let facultyNumberElement = document.querySelector('#FNumber')
let gradeElement = document.querySelector('#grade')
let loadBtn = document.querySelector('th button')
let submitBtn = document.querySelector('form button')

url = 'https://stdents-541be.firebaseio.com/.json'
submitBtn.addEventListener('click', (submitBtnEvent) => {
    submitBtnEvent.preventDefault();

    if (!(areEmpty() && areValid())) {
        console.log('false');
    }
    let studentId = Number(idElement.value);
    let studentFNumber = Number(facultyNumberElement.value);

    (async function addStudent() {
        let studentsPromise = await fetch(url);
        let students = await studentsPromise.json();
        if (students != null && Object.values(students).some(s => s.id == studentId || s.facultyNumber == studentFNumber)) {
            alert('There is existing student with this ID or Faculty Number. Please try again!')
            return
        }

        let student = {
            id: studentId,
            firstName: firstNameElement.value,
            lastName: lastNameElement.value,
            facultyNumber: studentFNumber,
            grade: Number(gradeElement.value)
        }



        Promise.all([students])
            .then(fetch(url, { method: 'POST', body: JSON.stringify(student) })
                .catch(err => console.log(err)))


        idElement.value = ''
        firstNameElement.value = ''
        lastNameElement.value = ''
        facultyNumberElement.value = ''
        gradeElement.value = ''
    })()


})

loadBtn.addEventListener('click', () => {
    let tbodyElement = document.querySelector('tbody');
    if (tbodyElement.childElementCount > 0) {
        tbodyElement.innerHTML = '';
    }
    fetch(url)
        .then(response => response.json())
        .then(data => {
            let result = ''
            Object.values(data)
                .sort((curr, next) => curr.id - next.id)
                .forEach(s => {
                    tbodyElement.innerHTML += `<tr><td>${s.id}</td><td>${s.firstName}</td><td>${s.lastName}</td><td>${s.facultyNumber}</td><td>${s.grade}</td></tr>`
                });
        })
})
function areEmpty() {
    return idElement.value != '' &&
        firstNameElement.value != '' &&
        lastNameElement.value != '' &&
        facultyNumberElement.value != '' &&
        gradeElement.value != ''
}

function areValid() {
    return idElement.value.match("^[0-9]+$") &&
        firstNameElement.value.match("^[A-Za-z]+$") &&
        lastNameElement.value.match("^[A-Za-z]+$") &&
        facultyNumberElement.value.match("^[0-9]+$") &&
        gradeElement.value.match("^[0-9]+$")
}

