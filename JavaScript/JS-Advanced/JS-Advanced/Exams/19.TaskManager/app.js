function solve() {
    const sections = document.querySelectorAll('section');
    const open = sections.item(1).querySelectorAll('div').item(1);
    const inProgress = sections.item(2).querySelectorAll('div').item(1);
    const complete = sections.item(3).querySelectorAll('div').item(1);

    const inputTask = document.getElementById('task');
    const inputDescription = document.getElementById('description');
    const inputDate = document.getElementById('date');

    const addBtn = document.getElementById('add');
    addBtn.addEventListener('click', addTask);

    function addTask(ev) {
        ev.preventDefault();

        const task = inputTask.value.trim();
        const description = inputDescription.value.trim();
        const date = inputDate.value.trim();

        if (task.length <= 0 || description.length <= 0 || date.length <= 0) {
            return;
        }

        inputTask.value = '';
        inputDescription.value = '';
        inputDate.value = '';

        const startBtn = e('button', { className: 'green' }, 'Start');
        const finishBtn = e('button', { className: 'orange' }, 'Finish');
        const deleteBtn = e('button', { className: 'red' }, 'Delete');

        const btnDiv = e('div', { className: 'flex' },
            startBtn,
            deleteBtn
        );

        const taskElement = e('article', {},
            e('h3', {}, `${task}`),
            e('p', {}, `Description: ${description}`),
            e('p', {}, `Due Date: ${date}`),
            btnDiv);

        startBtn.addEventListener('click', () => {
            inProgress.appendChild(taskElement);
            startBtn.remove();
            btnDiv.appendChild(finishBtn);
        });

        finishBtn.addEventListener('click', () => {
            complete.appendChild(taskElement);
            btnDiv.remove();
        });

        deleteBtn.addEventListener('click', () => {
            taskElement.remove();
        });

        open.appendChild(taskElement);
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