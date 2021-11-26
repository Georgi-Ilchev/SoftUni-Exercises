const element = document.createElement('div');
const msg = document.createElement('span');
const closeBtn = document.createElement('span');
closeBtn.classList.add('closeBtn');
closeBtn.innerHTML = '&#10006;';

element.id = 'notification';
element.appendChild(msg);
element.appendChild(closeBtn);
closeBtn.addEventListener('click', clear);

export function notify(message) {
    msg.textContent = message;
    document.body.appendChild(element);

    setTimeout(clear, 3000);
}

export function clear() {
    element.remove();
}