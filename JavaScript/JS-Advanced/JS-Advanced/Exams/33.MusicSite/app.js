window.addEventListener('load', solve);

function solve() {
    let inputFields = document.querySelectorAll('input');
    let input = {
        genre: inputFields[0],
        name: inputFields[1],
        author: inputFields[2],
        date: inputFields[3]
    };

    let collection = document.querySelector('.all-hits-container');
    let savedSong = document.querySelector('.saved-container');
    let likes = document.querySelector('.likes p');

    let addBtn = document.getElementById('add-btn');
    addBtn.addEventListener('click', addSong);

    function addSong(ev) {
        ev.preventDefault();

        if (input.genre.value === '' ||
            input.name.value === '' ||
            input.author.value === '' ||
            input.date.value === '') {
            return;
        }

        let saveBtn = e('button', { className: `save-btn` }, 'Save song');
        let likeBtn = e('button', { className: `like-btn` }, 'Like song');
        let deleteBtn = e('button', { className: `delete-btn` }, 'Delete');

        saveBtn.addEventListener('click', saveSong);
        likeBtn.addEventListener('click', likeSong);
        deleteBtn.addEventListener('click', deleteSong);

        let divElement =
            e('div', { className: 'hits-info' },
                e('img', { src: './static/img/img.png' }),
                e('h2', {}, `Genre: ${input.genre.value}`),
                e('h2', {}, `Name: ${input.name.value}`),
                e('h2', {}, `Author: ${input.author.value}`),
                e('h3', {}, `Date: ${input.date.value}`),
                saveBtn,
                likeBtn,
                deleteBtn);

        collection.appendChild(divElement);

        input.genre.value = '';
        input.name.value = '';
        input.author.value = '';
        input.date.value = '';

        function saveSong(ev) {
            let div = ev.currentTarget.parentElement;
            savedSong.appendChild(div);

            let buttons = div.querySelectorAll('button');
            let saveBtn = buttons[0];
            let likeBtn = buttons[1];

            saveBtn.remove();
            likeBtn.remove();
        }

        function likeSong(ev) {
            let btn = ev.currentTarget;
            let textCont = likes.textContent.split(' ');
            let count = Number(textCont[2]);
            count++;

            likes.textContent = `Total Likes: ${count}`;
            btn.disabled = true;
        }

        function deleteSong(ev) {
            let div = ev.currentTarget.parentElement;
            div.remove();
        }
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }

        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}