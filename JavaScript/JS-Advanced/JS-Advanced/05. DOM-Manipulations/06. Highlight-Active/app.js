function focus() {
    let inputs = document.querySelectorAll('input[type="text"]');

    Array.from(inputs).forEach(x => {
        x.addEventListener('focus', function (e) {
            let parentDivElement = e.currentTarget.parentElement;

            parentDivElement.classList.add('focused')
        });

        x.addEventListener('blur', function (e) {
            let parentDivElement = e.currentTarget.parentElement;

            parentDivElement.classList.remove('focused');
        });
    });
}

function focus() {
    let divs = document.getElementsByTagName('div')[0].children;
    for (let i = 0; i < divs.length; i++) {
        divs[i].lastElementChild.addEventListener('focus', makeFocused);
        // divs[i].addEventListener('focus', makeFocused);
    }

    function makeFocused() {
        let currentDiv = this.parentElement;

        for (let i = 0; i < divs.length; i++) {
            if (divs[i] !== currentDiv) {
                divs[i].classList.remove('focused');
            }
        }

        currentDiv.classList.add('focused');
    }
}