function solve() {
    let addBtn = document.querySelector('.admin-view .action button');
    let modules = {};

    addBtn.addEventListener('click', addLecture);

    function addLecture(ev) {
        ev.preventDefault();

        let lNameInput = document.querySelector('input[name="lecture-name"]');
        let lDateInput = document.querySelector('input[name="lecture-date"]');
        let lModuleInput = document.querySelector('select[name="lecture-module"]');

        if (!lNameInput.value || !lDateInput.value || lModuleInput.value == 'Select module') {
            return;
        }

        if (!modules[lModuleInput.value]) {
            modules[lModuleInput.value] = [];
        }

        let currentLecture = {
            name: lNameInput.value,
            date: formatDate(lDateInput.value),
        };

        modules[lModuleInput.value].push(currentLecture);

        lNameInput.value = '';
        lDateInput.value = '';
        lModuleInput.value = 'Select module';

        createTrainings(modules);
    }

    function createTrainings(modules) {
        let modulesElement = document.querySelector('.modules');
        modulesElement.innerHTML = '';

        for (const moduleName in modules) {
            let moduleElement = createModule(moduleName);
            let lectureList = document.createElement('ul');

            let lectures = modules[moduleName];
            lectures
                .sort((a, b) => a.date.localeCompare(b.date))
                .forEach(lecture => {
                    let lectureElement = createLecture(lecture.name, lecture.date);
                    lectureList.appendChild(lectureElement);

                    lectureElement.querySelector('button').addEventListener('click', (e) => {
                        modules[moduleName] = modules[moduleName]
                            .filter(x => !(x.name == lecture.name && x.date == lecture.date))

                        if (modules[moduleName].length == 0) {
                            delete modules[moduleName];
                            // e.currentTarget.closest('.module').remove();
                            e.currentTarget.parentNode.parentNode.parentNode.remove();
                        } else {
                            e.currentTarget.parentNode.remove();
                        }
                    });
                });

                // .forEach(({ name, date }) => {
                //     let lectureElement = createLecture(name, date);
                //     lectureList.appendChild(lectureElement);

                //     lectureElement.querySelector('button').addEventListener('click', (e) => {
                //         modules[moduleName] = modules[moduleName]
                //             .filter(x => !(x.name == name && x.date == date));

                //         if (modules[moduleName].length == 0) {
                //             delete modules[moduleName];
                //             e.currentTarget.parentNode.parentNode.parentNode.remove();
                //         } else {
                //             e.currentTarget.parentNode.remove();
                //         }
                //     });
                // });

            moduleElement.appendChild(lectureList);
            modulesElement.appendChild(moduleElement);
        }
    }

    function createModule(name) {
        let div = document.createElement('div');
        div.classList.add('module');

        let headingElement = document.createElement('h3');
        headingElement.textContent = `${name.toUpperCase()}-MODULE`;

        div.appendChild(headingElement);

        return div;
    }

    function createLecture(name, date) {
        let liElement = document.createElement('li');
        liElement.classList.add('flex');

        let courseHeadingElement = document.createElement('h4');
        courseHeadingElement.textContent = `${name} - ${date}`;

        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('red');
        deleteBtn.textContent = 'Del';

        liElement.appendChild(courseHeadingElement);
        liElement.appendChild(deleteBtn);

        return liElement;
    }

    function formatDate(dateInput) {
        let [date, time] = dateInput.split('T');
        // date = date.replaceAll('-', '/');
        date = date.replace(/-/g, '/');

        return `${date} - ${time}`;
    }
}