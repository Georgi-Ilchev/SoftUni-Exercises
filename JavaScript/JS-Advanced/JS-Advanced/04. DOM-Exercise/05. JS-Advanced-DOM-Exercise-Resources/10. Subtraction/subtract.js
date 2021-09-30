function subtract() {
    const result = document.getElementById('result');
    const num1 = document.getElementById('firstNumber').value;
    const num2 = document.getElementById('secondNumber').value;

    result.innerHTML = (Number(num1) - Number(num2).toString());
}