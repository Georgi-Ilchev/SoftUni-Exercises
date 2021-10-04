function sum(number) {
    let sum = number;

    function add(number2) {
        sum += number2;
        return add;
    }

    add.toString = () => {
        return sum;
    }

    return add;
}