function solve() {
    let addButton = document.getElementById('add');
    let task = document.getElementById('task');
    let description = document.getElementById('description');
    let date = document.getElementById('date');

    let sections = document.getElementsByTagName('section');
    let openSection = sections[1];
    let inProgressSection = sections[2];
    let completeSection = sections[3];

    addButton.addEventListener('click', createAndAppend);

    function createAndAppend(ev) {
        ev.preventDefault();

        if (task.value == '' ||
            description.value == '' ||
            date.value == '') {

            return;
        }

        let article = createElement('article');
        let h3 = createElement('h3', task.value);
        let pDescription = createElement('p', 'Description: ' + description.value);
        let pDate = createElement('p', 'Due Date: ' + date.value);
        let flexClass = createElement('div', undefined, 'flex');
        let startBtn = createElement('button', 'Start', 'green');
        let deleteBtn = createElement('button', 'Delete', 'red');

        flexClass.appendChild(startBtn);
        flexClass.appendChild(deleteBtn);

        article.appendChild(h3);
        article.appendChild(pDescription);
        article.appendChild(pDate);
        article.appendChild(flexClass);

        openSection.children[1].appendChild(article);

        task.value = '';
        description.value = '';
        date.value = '';

        deleteBtn.addEventListener('click', e => {
            article.remove();
        });

        startBtn.addEventListener('click', e => {
            inProgressSection.children[1].appendChild(article);

            let finishBtn = createElement('button', 'Finish', 'orange');
            startBtn.remove();

            flexClass.appendChild(finishBtn);
            finishBtn.addEventListener('click', ev => {
                completeSection.children[1].appendChild(article);
                flexClass.remove();
            });
        });
    }

    function createElement(type, text, className) {
        let result = document.createElement(type);
        result.textContent = text;

        if (className) {
            result.className = className;
        }

        return result;
    }
}