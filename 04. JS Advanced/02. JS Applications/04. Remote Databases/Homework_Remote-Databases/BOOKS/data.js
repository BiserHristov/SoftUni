
let titleElement = document.querySelector('#title');
let authorElement = document.querySelector('#author');
let isbnElement = document.querySelector('#isbn');
let submitBtn = Array.from(document.querySelectorAll('button')).find(b => b.textContent == 'Submit');
let baseURL = 'https://my-books-62add.firebaseio.com/'

function host(endpoint) {
    let result = `https://my-books-62add.firebaseio.com/${endpoint}.json`

    return result;
}

export async function getBooks() {

    let getBooksPromise = await fetch(host(''))
    let getBooksData = await getBooksPromise.json()
    return getBooksData;

}

export async function createBook(book) {

    let createBookPromise = await fetch(host(''), {
        method: 'POST',
        body: JSON.stringify(book),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    let createBookData = await createBookPromise.json()


    // return createBookData;
}

export async function editBook(editKey, editedBook) {

    let editedBookPromise = await fetch(host(`${editKey}`), {
        method: 'PATCH',
        body: JSON.stringify(editedBook),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    let editedBookData = await editedBookPromise.json()


    return editedBookData;


}

export async function deleteBook(deleteKey) {
    // let key = this.getAttribute('data-key');
    let deleteBookPromise = await fetch(host(`${deleteKey}`), { method: 'DELETE' })
    let deleteBookData = await deleteBookPromise.json()
    // this.parentElement.parentElement.remove();

    return deleteBookData;

}