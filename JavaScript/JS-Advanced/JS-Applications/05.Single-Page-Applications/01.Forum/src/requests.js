// Topic
async function createTopic(data, date) {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ ...data, creationDate: date })
    });

    return await response.json();
}

async function getTopics() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    const data = await response.json();

    return Object.values(data);
}

// Comment
async function createComment(data, topicName) {
    await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ ...data, topicName })
    })
}

async function getComments(topicName) {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    const data = await response.json();
    const comments = Object.values(data).filter(c => c.topicName === topicName);

    return comments;
}

export { createTopic, getTopics, createComment, getComments };