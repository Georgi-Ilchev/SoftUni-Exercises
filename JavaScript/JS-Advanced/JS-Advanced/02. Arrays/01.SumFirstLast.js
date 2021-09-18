//01. Sum First Last
function solve(input) {
    let firstNum = Number(input[0]);
    let lastNum = Number(input[input.length - 1]);

    let sum = firstNum + lastNum;
    console.log(sum);
};

// solve(['20', '30', '40']);
// solve(['5', '10']);


function sumFirstLast(array) {
    let first = Number(array.shift());
    let last = Number(array.pop());

    return first + last;
}

sumFirstLast(['20', '30', '40']);