function solve(input) {
    let positiveNumbers = [];
    let negativeNumbers = [];

    for (let i = 0; i < input.length; i++) {
        if (input[i] < 0 && input[i] >= Number.NEGATIVE_INFINITY) {
            negativeNumbers.push(Number(input[i]));
        } else {
            positiveNumbers.push(Number(input[i]));
        }
    }

    negativeNumbers.sort();

    negativeNumbers.forEach(
        x => console.log(x)
    );

    positiveNumbers.forEach(
        x => console.log(x)
    );
};
solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);
//75 points 