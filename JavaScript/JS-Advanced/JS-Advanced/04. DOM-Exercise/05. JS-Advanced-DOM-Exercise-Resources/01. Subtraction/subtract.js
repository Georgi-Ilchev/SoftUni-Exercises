function subtract() {
    let firstNumberValue = document.getElementById('firstNumber').value;
    let secondNumberValue = document.getElementById('secondNumber').value;

    let result = Number(firstNumberValue) - Number(secondNumberValue);

    let div = document.getElementById('result');
    div.innerText = result;
}