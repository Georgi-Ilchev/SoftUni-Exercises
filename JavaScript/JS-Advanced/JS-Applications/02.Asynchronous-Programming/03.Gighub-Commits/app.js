function loadCommits() {
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const ulElement = document.getElementById('commits');

    let url = `https://api.github.com/repos/${username}/${repo}/commits`;

    fetch(url)
        .then(res => {
            if (res.ok === false) {
                throw new Error(`Error: ${res.status} (Not Found)`);
            }
            return res.json();
        })
        .then(handleResponse)
        .catch(handleError);

    function handleResponse(data) {
        ulElement.textContent = '';

        Object.entries(data).forEach(el => {
            let liElement = document.createElement('li');
            liElement.textContent = `${el[1].commit.author.name} : ${el[1].commit.message}`;

            ulElement.appendChild(liElement);
        });
    }

    function handleError(error) {
        ulElement.textContent = '';

        let liElement = document.createElement('li');
        liElement.textContent = `${error.message}`;
        ulElement.appendChild(liElement);
    }
}