//string
let stringVariable1 = 'some text';
let stringVariable2 = "some text";

//number
let numberVariable1 = 10;
let numberVariable2 = 3.123;

//boolean
let booleanVariable1 = true;
let booleanVariable2 = false;

//undefined;
let someVariable;

//null
let someNullVariable = null;

//symbol
let sym1 = Symbol();
let sym2 = Symbol('jtdPerformance');
let sym3 = Symbol('sometext');

console.log(typeof sym2);

//constructor
Symbol();

//object
let obj1 = Object(sym2);
console.log(typeof sym2);

//parse
console.log(Number('4'));
console.log(Number('4.4'));
console.log(+'4' + 2);
console.log('4' + 2)


//exponentiation
let a = 15;
let b = 5;
let c;

c = a ** b;
console.log(c);


console.log(someVariable);
console.log(someNullVariable);
console.log(sym2);

//1. String Length
function solve1(arg1, arg2, arg3) {
    let sumLength;
    let averageLenght

    let firstArgLength = arg1.length;
    let secondArgLength = arg2.length;
    let thirdArgLength = arg3.length;

    sumLength = firstArgLength + secondArgLength + thirdArgLength;
    averageLenght = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLenght);
};

let arg1 = 'chocolate';
let arg2 = 'ice cream';
let arg3 = 'cake';

solve1(arg1, arg2, arg3);


//2. Math Operations
function solve2(num1, num2, operation) {
    let result;

    switch (operation) {
        case "+": result = num1 + num2; break;
        case "-": result = num1 - num2; break;
        case "*": result = num1 * num2; break;
        case "/": result = num1 / num2; break;
        case "%": result = num1 % num2; break;
        case "**": result = num1 ** num2; break;
    }
    console.log(result);
};

solve2(3, 5.5, '*');


//03. Sum of Numbers N…M
function solve3(n, m) {
    // let num1 = +n;
    // let num2 = +m;
    let result = 0;
    let num1 = Number(n);
    let num2 = Number(m);

    for (let i = num1; i <= num2; i++) {
        result += i;
    }

    return result;
};

console.log(solve3('-8', '20'));


//04. Largest Number
function solve4(num1, num2, num3) {
    let result = Math.max(num1, num2, num3);

    console.log(`The largest number is ${result}.`)
};

solve4(5, -3, 16);



//05. Circle Area
function solve5(input) {
    let result;
    let inputType = typeof (input);

    if (inputType === 'number') {
        result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
};

solve5(5);
solve5('name');


//06. Square of Stars
function solve6(n) {
    for (let row = 0; row < n; row++) {
        console.log(`${'* '.repeat(n)}`);
    }
};

solve6(5);


//7. Day of Week
function solve7(input) {
    let result;

    if (input == "Monday") {
        result = 1;
    }
    else if (input == "Tuesday") {
        result = 2;
    }
    else if (input == "Wednesday") {
        result = 3;
    }
    else if (input == "Thursday") {
        result = 4;
    }
    else if (input == "Friday") {
        result = 5;
    }
    else if (input == "Saturday") {
        result = 6;
    }
    else if (input == "Sunday") {
        result = 7;
    }
    else {
        result = "error";
    }

    console.log(result);
};

solve7("Sunday");


//8. Aggregate Elements
function solve8(input) {
    let elements = input.map(Number);
    aggregate(elements, 0, (a, b) => a + b);
    aggregate(elements, 0, (a, b) => a + 1 / b);
    aggregate(elements, "", (a, b) => a + b);

    function aggregate(arr, initVal, func) {
        let val = initVal;
        for (let i = 0; i < arr.length; i++) {
            val = func(val, arr[i]);
        }
        console.log(val);
    }
}

solve8([1, 2, 3]);
