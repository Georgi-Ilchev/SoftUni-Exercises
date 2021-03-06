function solve(input) {
    let arr = [];

    for (let i = 1; i < input.length; i += 2) {
        arr.push(input[i] * 2);
    }
    arr.reverse();
    console.log(arr.join(' '));
};
solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);



function solve1(input) {
    let result = input
        .filter((x, i) => i % 2 != 0)
        .map(x => x * 2)
        .reverse();
    console.log(result.join(' '));
};
solve1([10, 15, 20, 25]);
solve1([3, 0, 10, 4, 7, 3]);