function solution() {
    const [gifts, sent, discarded] = document.querySelectorAll('section ul');
    const input = document.querySelector('.card input');
    const addBtn = document.querySelector('.card button');

    addBtn.addEventListener('click', addGift);

    function addGift(ev) {
        const name = input.value;
        input.value = '';

        const element = e('li', name, 'gift');
        const sendBtn = e('button', 'Send', 'sendButton');
        const discardBtn = e('button', 'Discard', 'discardButton');

        element.appendChild(sendBtn);
        element.appendChild(discardBtn);

        sendBtn.addEventListener('click', () => dispatchGift(sent, name, element));
        discardBtn.addEventListener('click', () => dispatchGift(discarded, name, element));

        gifts.appendChild(element);

        //1
        // sortGifts();

        //2
        let inserted = false;
        for (const child of Array.from(gifts.children)) {
            if (child.textContent.localeCompare(element.textContent) == 1) {
                gifts.insertBefore(element, child);
                inserted = true;
                break;
            }
        }
        if (!inserted) {
            gifts.appendChild(element);
        }
    }

    function dispatchGift(target, name, gift) {
        gift.remove();

        const element = e('li', name, 'gift');

        target.appendChild(element);
    }

    function sortGifts(ev) {
        Array.from(gifts.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(g => gifts.appendChild(g));

        // .sort((a, b) => a.childNodes[0].textContent.localeCompare(b.childNodes[0].textContent));
    }

    function e(type, content, className) {
        const result = document.createElement(type);
        result.textContent = content;
        if (className) {
            result.className = className;
        }

        return result;
    }
}