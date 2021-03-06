//100 points
function attachGradientEvents() {
    let gradienElement = document.getElementById('gradient');
    let result = document.getElementById('result');

    gradienElement.addEventListener('mousemove', e => {
        let offsetX = e.offsetX
        let width = e.currentTarget.clientWidth

        let percent = Math.floor(offsetX / width * 100)
        result.textContent = `${percent}%`;
    });

    gradienElement.addEventListener('mouseout', () => {
        result.textContent = '';
    });
}

//100 points
function attachGradientEvents() {
    let resultBox = document.getElementById('result');
    let gradientBox = document.getElementById('gradient');

    gradientBox.addEventListener('mousemove', attachPosition);
    gradientBox.addEventListener('mouseout', clearPercentage);

    function attachPosition(event) {
        let currentMouseX = event.offsetX;
        let percentage = Math.floor(currentMouseX / this.clientWidth * 100);
        resultBox.textContent = percentage + '%';
    }

    function clearPercentage() {
        resultBox.textContent = '';
    }
}