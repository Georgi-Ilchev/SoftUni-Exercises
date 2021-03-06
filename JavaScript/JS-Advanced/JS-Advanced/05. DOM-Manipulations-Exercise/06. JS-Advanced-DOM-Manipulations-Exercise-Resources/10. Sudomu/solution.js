function solve() {
    let inputs = document.querySelectorAll('input');

    let quickCheck = document.querySelectorAll('button')[0];
    let clear = document.querySelectorAll('button')[1];

    quickCheck.style.cursor = 'pointer';
    clear.style.cursor = 'pointer';

    let table = document.querySelector('table');
    let output = document.querySelectorAll('#check p')[0];

    quickCheck.addEventListener('click', checkResult);
    clear.addEventListener('click', clearInput);

    function checkResult() {
        let matrix = [
            [inputs[0].value, inputs[1].value, inputs[2].value],
            [inputs[3].value, inputs[4].value, inputs[5].value],
            [inputs[6].value, inputs[7].value, inputs[8].value],
        ];

        let isSudomu = true;

        for (let index = 1; index < matrix.length; index++) {
            let row = matrix[index];
            let col = matrix.map(row => row[index]);

            if (row.length != [...new Set(row)].length ||
                col.length != [...new Set(col)].length) {

                isSudomu = false;
                break;
            }
        }

        if (isSudomu) {
            table.style.border = '2px solid green';
            output.style.color = 'green';
            output.textContent = 'You solve it! Congratulations!';
        } else {
            table.style.border = '2px solid red';
            output.style.color = 'red';
            output.textContent = 'NOP! You are not done yet...';
        }
    }

    function clearInput() {
        [...inputs].forEach(input => input.value = '');
        output.textContent = '';
        table.style.border = 'none';
    }
}