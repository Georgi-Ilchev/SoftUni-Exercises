const monthNames = {
    'Jan': 1,
    'Feb': 2,
    'Mar': 3,
    'Apr': 4,
    'May': 5,
    'Jun': 6,
    'Jul': 7,
    'Aug': 8,
    'Sept': 9,
    'Oct': 10,
    'Nov': 11,
    'Dec': 12,
};

const yearSelect = document.getElementById('years');
console.log(yearSelect);
const years = [...document.querySelectorAll('.monthCalendar')].reduce((acc, c) => {
    acc[c.id] = c;
    return acc;
}, {});

const months = [...document.querySelectorAll('.daysCalendar')].reduce((acc, c) => {
    acc[c.id] = c;
    return acc;
}, {});

displaySection(yearSelect);

yearSelect.addEventListener('click', (ev) => {
    if (ev.target.classList.contains('date') ||
        ev.target.classList.contains('day')) {

        ev.stopImmediatePropagation();
        const yearId = `year-${ev.target.textContent.trim()}`;
        displaySection(years[yearId]);
    }
})

document.body.addEventListener('click', (ev) => {
    if (ev.target.tagName === 'CAPTION') {
        const sectionId = ev.target.parentNode.parentNode.id;

        if (sectionId.includes('year-')) {
            displaySection(yearSelect);
        } else if (sectionId.includes('month-')) {
            const yearId = `year-${sectionId.split('-')[1]}`; //month-2020-6
            displaySection(years[yearId]);
        }
    } else if (ev.target.tagName == 'TD' || ev.target.tagName == 'DIV') {
        const monthName = ev.target.textContent.trim();

        if (monthNames.hasOwnProperty(monthName)) {
            let parent = ev.target.parentNode;
            while (parent.tagName != 'TABLE') {
                parent = parent.parentNode;
            }

            const year = parent.querySelector('caption').textContent.trim();
            const monthId = `month-${year}-${monthNames[monthName]}`;
            displaySection(months[monthId]);
        }
    }
});

function displaySection(section) {
    document.body.innerHTML = '';
    document.body.appendChild(section);
}