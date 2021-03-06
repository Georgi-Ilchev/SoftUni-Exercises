function solve() {
    let expression = document.getElementById('expressionOutput');
    let result = document.getElementById('resultOutput');

    document.querySelector('.keys').addEventListener('click', symbolClicked);
    document.querySelector('.clear').addEventListener('click', clear);

    function symbolClicked(event) {
        let buttonClicked = event.target.value;

        switch (buttonClicked) {
            case "+":
            case "-":
            case "*":
            case "/":
                expression.textContent += ` ${buttonClicked} `;
                break;

            case "=":
                let [leftOperand, operator, rightOperand] = expression.textContent.split(' ');

                if (!rightOperand || !operator) {
                    result.textContent = 'NaN';
                } else {
                    result.textContent = calculateResult(+leftOperand, operator, +rightOperand);
                }
                break;
            default:
                expression.textContent += buttonClicked;
        }
    }

    function calculateResult(leftOperand, operator, rightOperand) {
        switch (operator) {
            case '*':
                return leftOperand * rightOperand;
            case '/':
                return leftOperand / rightOperand;
            case '+':
                return leftOperand + rightOperand;
            case '-':
                return leftOperand - rightOperand;
        }
    }

    function clear() {
        expression.textContent = '';
        result.textContent = '';
    }
}