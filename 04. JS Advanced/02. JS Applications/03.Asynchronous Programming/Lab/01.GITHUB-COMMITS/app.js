function loadCommits() {
    let username = document.querySelector('#username');
    let repository = document.querySelector('#repo');
    let ul = document.querySelector('#commits');

    let url = `https://api.github.com/repos/${username.value}/${repository.value}/commits`
    ul.innerHTML = '';

    fetch(url)
        //.then(response => response.json()
            //     {
            //     if (response.status != 200) {
            //         let li = document.createElement('li')
            //         li.textContent = `Error: ${response.status} (${response.statusText})`
            //         ul.appendChild(li);
            //         return;
            //     }

            //     return response.json()
            // }
        //)
        .then(data =>  console.log(data)
            // data.forEach(element => {
            //     let li = document.createElement('li')
            //     li.textContent = `${element.commit.author.name}: ${element.commit.message}`;
            //     ul.appendChild(li);
            // });
        )
        .catch((reason) => {
            let li = document.createElement('li')
            li.textContent = `Error: ${reason.status} (${reason.responseText})`
            ul.appendChild(li);
        })


}