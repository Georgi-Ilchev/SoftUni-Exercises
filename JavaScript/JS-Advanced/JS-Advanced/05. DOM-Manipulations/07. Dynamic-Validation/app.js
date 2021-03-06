function validate() {
    let input = document.getElementById('email');

    input.addEventListener('change', e => {
        let currentValue = e.currentTarget.value;

        let pattern = /[a-z]+@[a-z]+.[a-z]+/;

        if (pattern.test(currentValue)) {
            e.currentTarget.classList.remove('error');
        } else {
            e.currentTarget.classList.add('error');
        }
    })
}