function attachEvents() {
    let loadBtn = document.querySelector('#btnLoadPosts');
    let url = `https://blog-apps-c12bf.firebaseio.com/`;
    let selectElement = document.querySelector('#posts');

    loadBtn.addEventListener('click', () => {

        fetch(url + 'posts.json')
            .then(response => response.json())
            .then(data => {
                let options = Object.keys(data).map(key => `<option value="${key}">${data[key].title}</option>`).join('\n')
                selectElement.innerHTML = options;
            })


    })

    let postTitle = document.querySelector("#post-title");
    let postBody = document.querySelector("#post-body");
    let postComments = document.querySelector("#post-comments");

    selectElement.addEventListener('change', (event) => {
        fetch(url + `posts/${event.target.value}.json`)
            .then(response => response.json())
            .then(data => {

                postTitle.textContent = `${data.title}`
                postBody.textContent = `${data.body}`;

                let comments = data.comments.map(key => `<li>${key.text}</li>`).join('')
                postComments.innerHTML = comments

            })
    })
}

attachEvents();