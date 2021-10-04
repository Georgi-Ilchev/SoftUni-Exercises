function calculator() {
    let firstNum;
    let secondNum;
    let result;

    function init(selector1, selector2, selector3) {
        firstNum = document.querySelector(selector1);
        secondNum = document.querySelector(selector2);
        result = document.querySelector(selector3);
    }

    function add() {
        result.value = Number(firstNum.value) + Number(secondNum.value);
    }

    function subtract() {
        result.value = Number(firstNum.value) - Number(secondNum.value);
    }

    return {
        init,
        add,
        subtract
    };
}