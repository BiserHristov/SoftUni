import el from './dom.js'
import * as api from './data.js'


window.addEventListener('load', () => {
    let tbodyElement = document.querySelector('tbody');

    //Load Books
    document.querySelector('#loadBooks').addEventListener('click', loadBooks);

    async function loadBooks() {
        tbodyElement.innerHTML = '<tr><td colspan="4">Loading...</td></tr>'
        const books = await api.getBooks()
        tbodyElement.innerHTML = ''

        Object.entries(books)
            .forEach(([key, value]) => tbodyElement.appendChild(drawBook(key, value)))


    }

    function drawBook(key, book) {
        const deleteBtn = el('button', 'Delete');
        deleteBtn.setAttribute('data-key', `${key}`)

        const editBtn = el('button', 'Edit');
        editBtn.setAttribute('data-key', `${key}`)

        deleteBtn.addEventListener('click', deleteCurrentBook)
        editBtn.addEventListener('click', editCurrentBook)

        let element = el('tr', [
            el('td', book.title),
            el('td', book.author),
            el('td', book.isbn),
            el('td', [
                editBtn,
                deleteBtn
            ])

        ])

        return element;

        //Delete book
        async function deleteCurrentBook() {
            try {
                deleteBtn.disabled = true;
                deleteBtn.textContent = 'Please wait...'
                await api.deleteBook(key)
                element.remove()
            } catch (err) {
                deleteBtn.disabled = false;
                deleteBtn.textContent = 'Delete'
                alert(err)
                console.log(err)
            }
        }

        //Edit book
        function editCurrentBook() {

            //const currentKey = element.querySelector('button').getAttribute('data-key')
            const saveBtn = el('button', 'Save')
            const cancelBtn = el('button', 'Cancel')

            const edit = {
                title: el('input', null, { type: 'text', value: book.title }),
                author: el('input', null, { type: 'text', value: book.author }),
                isbn: el('input', null, { type: 'text', value: book.isbn })
            }

            const editorElement = el('tr', [
                el('td', edit.title),
                el('td', edit.author),
                el('td', edit.isbn),
                el('td', [
                    saveBtn,
                    cancelBtn
                ])

            ])

            saveBtn.addEventListener('click', async () => {
                const edited = {
                    title: edit.title.value,
                    author: edit.author.value,
                    isbn: edit.isbn.value,
                }


                //Book validation
                let isValid = true;
                Object.entries(edited).find(([key, value]) => {
                    if (value.length === 0) {
                        alert(`Book ${key} can not be empty!`)
                        isValid = false;
                        return true;
                    } else {
                        return false;
                    }
                })

                if (!isValid) {
                    return;
                }


                try {
                    await api.editBook(key, edited)

                    tbodyElement.replaceChild(drawBook(key, edited), editorElement)
                } catch (error) {
                    alert(error);
                    console.log((error));
                }

            })


            cancelBtn.addEventListener('click', () => {
                tbodyElement.replaceChild(element, editorElement)

            })
            tbodyElement.replaceChild(editorElement, element);



        }
    }

    //Create Book
    let titleElement = document.querySelector('#title');
    let authorElement = document.querySelector('#author');
    let isbnElement = document.querySelector('#isbn');
    let submitBtn = Array.from(document.querySelectorAll('button')).find(b => b.textContent == 'Submit');

    submitBtn.addEventListener('click', createBook)

    async function createBook(event) {
        event.preventDefault()

        const book = {
            title: titleElement.value,
            author: authorElement.value,
            isbn: isbnElement.value
        }


        //Book validation
        let isValid = true;
        Object.entries(book).find(([key, value]) => {
            if (value.length === 0) {
                alert(`Book ${key} can not be empty!`)
                isValid = false;
                return true;
            } else {
                return false;
            }
        })

        if (!isValid) {
            return;
        }


        try {
            await api.createBook(book);
        } catch (error) {
            alert(error);
            console.log((error));
        }


        titleElement.value = ''
        authorElement.value = ''
        isbnElement.value = ''

    }


})



//ANOTHER WORKING SOLUTION

// let titleElement = document.querySelector('#title');
// let authorElement = document.querySelector('#author');
// let isbnElement = document.querySelector('#isbn');
// let submitBtn = Array.from(document.querySelectorAll('button')).find(b => b.textContent == 'Submit');
// let baseURL = 'https://my-books-62add.firebaseio.com/'

// submitBtn.addEventListener('click', (submitBtnEvent) => {
//     submitBtnEvent.preventDefault();
//     let book = {
//         title: titleElement.value,
//         author: authorElement.value,
//         isbn: isbnElement.value
//     }

//     fetch(baseURL + '.json', { method: 'POST', body: JSON.stringify(book) })
//         .catch(err => console.log(err.message))

//     titleElement.value = ''
//     authorElement.value = ''
//     isbnElement.value = ''
// })

// let loadBooksBtn = document.querySelector('#loadBooks');
// loadBooksBtn.addEventListener('click', () => loadAllBooks())
// function loadAllBooks() {
//     let tbodyElement = document.querySelector('tbody');
//     if (tbodyElement.innerHTML != '') {
//         tbodyElement.innerHTML = ''
//     }

//     fetch(baseURL + '.json')
//         .then(res => res.json())
//         .then(data => {
//             Object.keys(data)
//                 .forEach(key => {
//                     let tr = createDomElement('tr', '', {}, {},
//                         createDomElement('td', `${data[key].title}`, {}, {}),
//                         createDomElement('td', `${data[key].author}`, {}, {}),
//                         createDomElement('td', `${data[key].isbn}`, {}, {}),
//                         createDomElement('td', '', {}, {},
//                             createDomElement('button', 'Edit', { 'data-key': `${key}` }, { click: loadEditForm }),
//                             createDomElement('button', 'Delete', { 'data-key': `${key}` }, { click: deleteBook })))

//                     tbodyElement.appendChild(tr)
//                 })

//         })
//         .catch(err => console.log(err.message))
// }
// function deleteBook() {
//     let key = this.getAttribute('data-key');
//     fetch(baseURL + `/${key}.json`, { method: 'DELETE' })
//         .catch(err => console.log(err.message))
//     this.parentElement.parentElement.remove();

// }
// function loadEditForm() {
//     let key = this.getAttribute('data-key');
//     let title = this.parentElement.parentElement.children[0].textContent;
//     let author = this.parentElement.parentElement.children[1].textContent;
//     let isbn = this.parentElement.parentElement.children[2].textContent;
//     document.querySelector('#editForm').style.display = 'block';
//     let editFormBtn = document.querySelector('#editForm button');
//     editFormBtn.setAttribute('data-key', `${key}`)
//     document.querySelector("#edit-title").value = title;
//     document.querySelector("#edit-author").value = author;
//     document.querySelector("#edit-isbn").value = isbn;

//     editFormBtn.addEventListener('click', (editFormBtnEvent) => {
//         editFormBtnEvent.preventDefault();
//         let editedObj = {
//             title: document.querySelector("#edit-title").value,
//             author: document.querySelector("#edit-author").value,
//             isbn: document.querySelector("#edit-isbn").value
//         }

//         fetch(baseURL + `/${key}.json`, { method: 'PATCH', body: JSON.stringify(editedObj) })
//             .then(
//                 document.querySelector('#editForm').style.display = 'none'

//             )
//             .catch(err => console.log(err.message))

//         loadAllBooks();


//     })

// }





// function createDomElement(type, content, attributes, events, ...children) {
//     let result = document.createElement(type);

//     if (content) {
//         result.textContent = content;
//     }

//     if (attributes) {
//         Object.entries(attributes)
//             .forEach(([key, value]) => {
//                 result.setAttribute(key, value)
//             })
//     }

//     if (events) {
//         Object.entries(events)
//             .forEach(([eventName, eventHandler]) => {
//                 result.addEventListener(eventName, eventHandler)
//             })
//     }

//     if (children.length != 0) {
//         result.append(...children)
//     }


//     return result;
// }

