function attachEvents() {
    let sendBtn = document.querySelector('#submit');
    let refreshBtn = document.querySelector('#refresh');
    let authorEl = document.querySelector('#author');
    let contentEl = document.querySelector('#content');
    let textArea = document.querySelector('#messages');

    let url = 'https://rest-messanger.firebaseio.com/messanger.json'

    sendBtn.addEventListener('click', () => {
        let message = {
            author: authorEl.value,
            content: contentEl.value
        }

        fetch(url, { method: 'POST', body: JSON.stringify(message) })
        authorEl.value = ''
        contentEl.value = ''
    })

    refreshBtn.addEventListener('click', () => {
        textArea.value = '';
        fetch(url)
            .then(response => response.json())
            .then(data => {
                Object.values(data).forEach(m => textArea.value += `${m.author}: ${m.content}\n`)
            })
    })

}

attachEvents();