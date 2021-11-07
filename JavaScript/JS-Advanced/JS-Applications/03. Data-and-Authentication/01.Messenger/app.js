function attachEvents() {
    const submitBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    submitBtn.addEventListener('click', submitMessage);
    refreshBtn.addEventListener('click', loadMessages);

    loadMessages();
}

const messageList = document.getElementById('messages');
const authorInput = document.querySelector('[name="author"]');
const contentInput = document.querySelector('[name="content"]');

async function submitMessage() {
    const author = authorInput.value;
    const content = contentInput.value;

    await createMessage({ author, content });

    contentInput.value = '';
    messageList.value = '\n' + `${author}: ${content}`;
}

async function loadMessages() {
    const url = `http://localhost:3030/jsonstore/messenger`;

    const response = await fetch(url);
    const data = await response.json();

    const messages = Object.values(data);

    messageList.value = messages.map(m => `${m.author}: ${m.content}`).join('\n');
}

async function createMessage(message) {
    const url = `http://localhost:3030/jsonstore/messenger`;
    const options = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(message)
    };

    const response = await fetch(url, options);
    const result = await response.json();

    return result;
}

attachEvents();