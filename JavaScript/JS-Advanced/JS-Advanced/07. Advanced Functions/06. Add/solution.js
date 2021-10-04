function solution(number) {
    let sum = number;

    return function (numberToAdd) {
        return numberToAdd + sum;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
console.log(add5(5));
