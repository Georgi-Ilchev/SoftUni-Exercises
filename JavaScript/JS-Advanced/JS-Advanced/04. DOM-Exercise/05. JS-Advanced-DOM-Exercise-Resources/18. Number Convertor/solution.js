function solve() {
    let input = document.getElementById('input');
    let selectTo = document.getElementById('selectMenuTo');
    let output = document.getElementById('result');

    createOptions();

    let button = document.querySelector('#container > button')
        .addEventListener('click', convert);

    function createOptions() {
        let binary = document.createElement('option');
        binary.textContent = 'Binary';
        binary.value = 'binary';
        selectTo.appendChild(binary);

        let hexadecimal = document.createElement('option');
        hexadecimal.textContent = 'Hexadecimal';
        hexadecimal.value = 'hexadecimal';
        selectTo.appendChild(hexadecimal);
    }

    function convert() {
        let num = Number(input.value);
        let result;

        if (selectTo.value === 'binary') {
            result = convertBinary();
        } else if (selectTo.value === 'hexadecimal') {
            result = convertHexadecimal();
        }

        output.value = result;

        function convertBinary() {
            return (num >>> 0).toString(2);
        }

        function convertHexadecimal() {
            return num.toString(16).toUpperCase();
        }
    }
}