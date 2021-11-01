function solution() {
    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;
    fetch(url)
        .then(res => res.json())
        .then(data => {
            loadArticles(data);
        })
        .catch();
}

function loadArticles(articles) {
    let main = document.getElementById('main');

    articles.forEach(article => {
        let p = e('p', {}, '');

        fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`)
            .then(res => res.json())
            .then(data => {
                loadDescription(p, data.content);
            })
            .catch();

        let divAccordion =
            e('div', { class: 'accordion' },
                e('div', { class: 'head' },
                    e('span', {}, article.title),
                    e('button', { class: 'button', onclick: showMore, id: article._id }, 'MORE')),
                e('div', { class: 'extra' },
                    p
                )
            );

        main.appendChild(divAccordion);
    })
}

function loadDescription(paragraph, content) {
    paragraph.textContent = content;
}

function showMore(e) {
    let nextSibling = e.target.parentElement.nextElementSibling;
    nextSibling.style.display = nextSibling.style.display == 'block' ? 'none' : 'block';
    e.target.textContent = e.target.textContent == 'MORE' ? 'LESS' : 'MORE';
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else if (attr == 'class') {
            result.classList.add(value);
        } else {
            result.setAttribute(attr, value);
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}


solution();



// function eFactory(tag, className = '', content = '') {
//     const e = document.createElement(tag)
//     e.className = className
//     e.textContent = content

//     return e
// }

// function template({ _id, title }) {
//     const wrapper = eFactory('div', 'accordion')
//     const headDiv = eFactory('div', 'head')
//     const titleSpan = eFactory('span', '', title)
//     const btn = eFactory('button', 'button', 'More')
//     const extraDiv = eFactory('div', 'extra')
//     extraDiv.style.display = 'none'
//     const contentParagraph = eFactory('p')
//     btn.id = _id

//     headDiv.append(titleSpan, btn)
//     extraDiv.appendChild(contentParagraph)
//     wrapper.append(headDiv, extraDiv)

//     btn.addEventListener('click', async () => {
//         if (extraDiv.style.display === 'none') {
//             const data = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${_id}`)
//             const desData = await data.json()
//             btn.textContent = 'Less'
//             extraDiv.style.display = 'block'
//             contentParagraph.textContent = desData.content
//         } else {
//             btn.textContent = 'More'
//             extraDiv.style.display = 'none'
//         }
//     })

//     return wrapper
// }

// async function solution() {
//     const output = document.getElementById('main')
//     const titles = await fetch('http://localhost:3030/jsonstore/advanced/articles/list')
//     const desTitles = await titles.json()

//     desTitles.forEach(x => output.appendChild(template(x)))
// }

// document.addEventListener('DOMContentLoaded', solution)





