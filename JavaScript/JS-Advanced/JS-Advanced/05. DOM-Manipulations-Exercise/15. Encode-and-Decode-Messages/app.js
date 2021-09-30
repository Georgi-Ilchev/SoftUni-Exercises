function encodeAndDecodeMessages() {
    let textarea = document.getElementsByTagName('textarea');
    [...document.getElementsByTagName('button')].forEach(b => b.addEventListener('click', processingMessage));

    function processingMessage(ev) {
        if (ev.target.textContent === 'Encode and send it') {
            let encoded = [...textarea[0].value].map(e => String.fromCharCode(e.charCodeAt(0) + 1)).join('');
            textarea[1].value = encoded;
            textarea[0].value = '';
        } else if (ev.target.textContent === 'Decode and read it') {
            let decoded = [...textarea[1].value].map(e => String.fromCharCode(e.charCodeAt(0) - 1)).join('');
            textarea[1].value = decoded;
        }
    }
}

function encodeAndDecodeMessages() {
    document.getElementById('main').addEventListener('click', processingMessage);

    function processingMessage(ev) {
        if (ev.target.tagName !== 'BUTTON') {
            return;
        }

        let encodedMessage = document.getElementsByTagName('textarea')[1];
        let decodedMessage = document.getElementsByTagName('textarea')[0];

        if (ev.target.textContent.includes('Encode')) {
            let message = decodedMessage.value;
            let encoded = [];

            for (let i = 0; i < message.length; i++) {
                let currentSymbol = message.charCodeAt(i);
                encoded.push(String.fromCharCode(currentSymbol + 1));
            }

            decodedMessage.value = '';
            encodedMessage.value = encoded.join('');
        } else if (ev.target.textContent.includes('Decode')) {
            let message = encodedMessage.value;
            let decoded = [];

            for (let i = 0; i < message.length; i++) {
                let currentSymbol = message.charCodeAt(i);
                decoded.push(String.fromCharCode(currentSymbol - 1));
            }

            encodedMessage.value = decoded.join('');
        }
    }
}