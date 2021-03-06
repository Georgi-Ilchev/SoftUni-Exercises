function notify(message) {
    let divNotification = document.getElementById('notification');

    divNotification.textContent = message;
    divNotification.style.display = 'block';

    setTimeout(() => {
        divNotification.style.display = 'none';
    }, 2000)
}