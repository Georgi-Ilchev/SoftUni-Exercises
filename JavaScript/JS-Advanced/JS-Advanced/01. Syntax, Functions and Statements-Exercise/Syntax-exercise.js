//01. Fruit

function solve1(fruit, weight, price) {
    weight = weight / 1000;
    let money = Number(weight) * Number(price);
    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
};
solve1('orange', 2500, 1.80);
solve1('apple', 1563, 2.35);

//02. Greatest Common Divisor – GCDGreatest Common Divisor – GCD

function solve2(first, second) {
    first = Math.abs(first);
    second = Math.abs(second);

    while (second) {
        var current = second;
        second = first % second;
        first = current;
    }
    console.log(first);
};
solve2(15, 5);
solve2(2154, 458);

//03. Same Numbers

function solve3(number) {
    // let sum = 0;
    // let lastDigit = number % 10;
    // let equalCount = 0;

    // while (number / 10 > 0) {
    //     let digit = number % 10;
    //     sum += digit;

    //     if (digit !== lastDigit) {
    //         equalCount++;
    //     }
    //     lastDigit = digit;
    //     number = Math.floor(number / 10);
    // }
    // console.log(equalCount === 0 ? true : false);
    // console.log(sum);

    //second way
    let number1 = number.toString().split("");
    let unique = number1[0];
    let flag = true;
    let sum = 0;

    for (const num of number1) {
        if (num != unique && flag) {
            console.log("false");
            flag = false;
        }
        sum += +num;
    }

    if (flag) {
        console.log("true");
    }
    console.log(sum);
};
solve3(2222222);
solve3(1234);

//04. Time to Walk
function solve4(steps, footLength, speed) {
    let distance = steps * footLength;
    let speedForMeterInSec = speed / 3.6;

    let rest = Math.floor(distance / 500);
    let time = distance / speedForMeterInSec + rest * 60;

    let hours = Math.floor(time / 3600);
    let mins = Math.floor(time / 60);
    let seconds = Math.ceil(time % 60);

    console.log(`${hours < 10 ? 0 : ""}${hours}:${mins < 10 ? 0 : ""}${mins}:${seconds < 10 ? 0 : ""}${seconds}`);

};
solve4(4000, 0.60, 5);
solve4(2564, 0.70, 5.5);

//05. Road Radar
function solve5(input) {
    let currentSpeed = Number(input[0]);
    let area = input[1];
    //currentSpeed, area
    switch (area) {
        case "motorway":
            let motorwayLimit = 130;
            if (currentSpeed <= motorwayLimit) {
                break;
            }
            else {
                speedOver(currentSpeed, motorwayLimit);
                break;
            }

        case "interstate":
            let intertateLimit = 90;
            if (currentSpeed <= intertateLimit) {
                break;
            }
            else {
                speedOver(currentSpeed, intertateLimit);
                break;
            }
        case "city":
            let cityLimit = 50;
            if (currentSpeed <= cityLimit) {
                break;
            }
            else {
                speedOver(currentSpeed, cityLimit);
                break;
            }
        case "residential":
            let residentialLimit = 20;
            if (currentSpeed <= residentialLimit) {
                break;
            }
            else {
                speedOver(currentSpeed, residentialLimit);
                break;
            }
    }

    function speedOver(currentSpeed, areaLimit) {
        if (currentSpeed - areaLimit <= 20) {
            console.log('speeding');
        }
        else if (currentSpeed - areaLimit > 20 && currentSpeed - areaLimit <= 40) {
            console.log('excessive speeding');
        }
        else {
            console.log('reckless driving');
        }
    }
};
solve5([40, 'city']);
solve5([21, 'residential']);
solve5([120, 'interstate']);
solve5([200, 'motorway']);


//06. Cooking by Numbers
function solve6(input) {
    //let number = Number(input[0]);
    let number = Number(input.shift());

    //for from 1
    for (let i = 0; i < input.length; i++) {
        switch (input[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.80;
                break;
        }
        console.log(number);
    }
};
solve6(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve6(['9', 'dice', 'spice', 'chop', 'bake', 'fillet'])


//07. Validity Checker
function solve7(input) {
    let x1 = Number(input.shift());
    let y1 = Number(input.shift());

    let x2 = Number(input.shift());
    let y2 = Number(input.shift());

    console.log(`{${x1}, ${y1}} to {0, 0} is ${checkValidity(isValid(x1, y1, 0, 0))}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${checkValidity(isValid(x2, y2, 0, 0))}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${checkValidity(isValid(x1, y1, x2, y2))}`);

    function isValid(x1, y1, x2, y2) {
        let value = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
        return Number.isInteger(value);
    }

    function checkValidity(validity) {
        return validity ? 'valid' : 'invalid';
    }
};

solve7([3, 0, 0, 4]);
solve7([2, 1, 1, 1]);

//08. Calorie Object
function solve8(input) {
    let obj = {};

    for (let i = 0; i < input.length; i += 2) {
        let food = input[i];
        let calories = Number(input[i + 1]);

        obj[food] = calories;
    }
    console.log(obj);
};
solve8(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
solve8(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);


//09. Words Uppercase
function solve9(text) {
    let result = text.toUpperCase()
        .split(/[\W]+/)
        .filter(w => w.length > 0)
        .join(", ");

    console.log(result);
};
solve9('Hi, how are you?');
solve9('hello')

function solve10(text) {
    let result = text.toUpperCase()
        .match(/\w+/g)
        .join(', ');

    console.log(result);
};
solve9('Hi, how are you?');
solve9('hello')