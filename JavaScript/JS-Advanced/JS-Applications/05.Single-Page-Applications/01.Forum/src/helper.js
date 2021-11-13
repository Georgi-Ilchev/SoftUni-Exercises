function e(tag, className = '', content = '') {
    const el = document.createElement(tag);
    el.classList.add(className);
    el.innerHTML = content;

    return el;
}

const isValidData = obj => Object.values(obj).every(x => x !== ''); // checking for empty fields

export { isValidData, e }