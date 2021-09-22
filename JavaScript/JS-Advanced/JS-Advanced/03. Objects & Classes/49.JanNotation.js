function calculate(params) {
    let operations = {
        '+': (first, second) => first + second,
        '-': (first, second) => first - second,
        '*': (first, second) => first * second,
        '/': (first, second) => first / second,
    }

    let numbers = [];
    for (const item of params) {
        if (Number.isFinite(item)) {
            numbers.push(item);
        } else {
            if (numbers.length < 2) {
                return 'Error: not enough operands!';
            } else {
                let second = numbers.pop();
                let first = numbers.pop();
                numbers.push(operations[item](first, second));
            }
        }
    }

    console.log(numbers.length > 1
        ? 'Error: too many operands!'
        : numbers[0]);
}

calculate([3,
    4,
    '+']
)

calculate([7,
    33,
    8,
    '-']
)