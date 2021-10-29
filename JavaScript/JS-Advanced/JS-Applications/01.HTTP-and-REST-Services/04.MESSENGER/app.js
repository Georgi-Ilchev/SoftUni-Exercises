function attachEvents() {
    let url = `https://rest-messanger.firebaseio.com/messanger.json`;

    let refreshBtn = document.getElementById('refresh');
    let submitBtn = document.getElementById('submit');

    refreshBtn.addEventListener('click', () => {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                let result = Object.values(data).reduce(
                    (messages, message) => (messages += `${message.author}: ${message.content}\n`)
                );

                document.getElementById('messages').textContent = result;
            });
    });

    submitBtn.addEventListener('click', () => {
        let author = document.getElementById('author');
        let content = document.getElementById('content');

        fetch(url, {
            method: 'POST',
            body: JSON.stringify({
                author: author.value,
                content: content.value
            })
        });

        author.value = '';
        content.value = '';
    });
}

attachEvents();