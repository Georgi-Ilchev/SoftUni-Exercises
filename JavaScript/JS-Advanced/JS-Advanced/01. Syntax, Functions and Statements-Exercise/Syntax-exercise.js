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
        let current = second;
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

//1. Fruit
function fruit(fruit, weight, price) {
    const weightInKg = weight / 1000
    const sum = weightInKg * price;

    console.log(`I need $${sum.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

fruit('orange', 2500, 1.80)

//2. Greatest Common Divisor - GCD
function gcd(first, second) {
    first = Math.abs(first);
    second = Math.abs(second);

    while (second) {
        let current = second;
        second = first % second;
        first = current;
    }
    console.log(first);
}

//3. Same Numbers
function sameNumbers(numInt) {
    const numStr = numInt.toString();
    let result = parseInt(numStr[0]);
    let isSame = true;

    for (let i = 1; i < numStr.length; i++) {
        result += parseInt(numStr[i]);

        if (numStr[i] != numStr[i - 1]) {
            isSame = false;
        }
    }
    console.log(isSame);
    console.log(result);
}

sameNumbers(2222222);
sameNumbers(1234);

//4. Previous Day
function previousDay(year, month, day) {
    let date = new Date(year, month - 1, day);
    let previousDay = new Date(date);

    previousDay.setDate(previousDay.getDate() - 1);

    console.log(`${previousDay.getFullYear()}-${previousDay.getMonth() + 1}-${previousDay.getDate()}`);
}

//5. Time to Walk
function timeToWalk(steps, footLength, speed) {
    let distance = steps * footLength;
    let speedForMeter = speed / 3.6;
    let rest = Math.floor(distance / 500);

    let time = distance / speedForMeter + rest * 60;

    let hours = Math.floor(time / 3600);
    let minutes = Math.floor(time / 60);
    let seconds = Math.ceil(time % 60);

    console.log(`${hours < 10 ? 0 : ""}${hours}:${minutes < 10 ? 0 : ""}${minutes}:${seconds < 10 ? 0 : ""}${seconds}`);
}

//6. Road Radar
function roadRadar(speed, area) {
    switch (area) {
        case "motorway":
            const motorwayLimit = 130;
            if (speed <= motorwayLimit) {
                console.log(`Driving ${speed} km/h in a ${motorwayLimit} zone`);
            } else {
                let status = speeding(speed, motorwayLimit);
                let overSpeed = speed - motorwayLimit;
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`);
            } break;

        case "interstate":
            const interstateLimit = 90;
            if (speed <= interstateLimit) {
                console.log(`Driving ${speed} km/h in a ${interstateLimit} zone`);
            } else {
                let status = speeding(speed, interstateLimit);
                let overSpeed = speed - interstateLimit;
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
            } break;

        case "city":
            const cityLimit = 50;
            if (speed <= cityLimit) {
                console.log(`Driving ${speed} km/h in a ${cityLimit} zone`);
            } else {
                let status = speeding(speed, cityLimit);
                let overSpeed = speed - cityLimit;
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
            } break;

        case "residential":
            const residentialLimit = 20;
            if (speed <= residentialLimit) {
                console.log(`Driving ${speed} km/h in a ${residentialLimit} zone`);
            } else {
                let status = speeding(speed, residentialLimit);
                let overSpeed = speed - residentialLimit;
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${residentialLimit} - ${status}`);
            } break;
    }

    function speeding(currentSpeed, areaLimit) {
        let overSpeed = currentSpeed - areaLimit;
        if (overSpeed <= 20) {
            return (`speeding`);
        } else if (overSpeed > 20 && overSpeed <= 40) {
            return (`excessive speeding`);
        } else {
            return (`reckless driving`);
        }
    }
}

roadRadar(21, "residential");

//7. Cooking by Numbers
function cookingByNumbers(number, op1, op2, op3, op4, op5) {
    // let number = Number(input[0]);

    // for (let i = 1; i < input.length; i++) {
    //     switch (input[i]) {
    //         case 'chop': 
    //             number /= 2;
    //             console.log(number);
    //             break;
    //         case 'dice': 
    //             number = Math.sqrt(number);
    //             console.log(number);
    //             break;
    //         case 'spice': 
    //             number += 1;
    //             console.log(number);
    //             break;
    //         case 'bake':
    //             number *= 3;
    //             console.log(number);
    //             break;
    //         case 'fillet':
    //             number *= 0.8;
    //             console.log(number.toFixed(1));
    //             break;
    //         default:
    //             break;
    //     }
    // }

    number = Number(number);

    let chop = function (n) {
        return n / 2;
    }

    let dice = function (n) {
        return Math.sqrt(n);
    }

    let spice = function (n) {
        return n + 1;
    }

    let bake = function (n) {
        return n * 3;
    }

    let fillet = function (n) {
        return n * 0.8;
    }

    const arr = [op1, op2, op3, op4, op5];
    let result = number;

    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case 'chop':
                result = chop(result);
                console.log(result);
                break;
            case 'dice':
                result = dice(result);
                console.log(result);
                break;
            case 'spice':
                result = spice(result);
                console.log(result);
                break;
            case 'bake':
                result = bake(result);
                console.log(result);
                break;
            case 'fillet':
                result = fillet(result);
                console.log(result);
                break;
            default:
                break;
        }
    }
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet')

//8. Validity Checker
function validityChecker(x1, y1, x2, y2) {
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
}

validityChecker(3, 0, 0, 4);

//9. *Words Uppercase
function wordsUppercase(text) {
    let result = text.toUpperCase()
        .match(/\w+/g)
        .join(', ');

    console.log(result);
}