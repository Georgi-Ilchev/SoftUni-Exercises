function solve(input, criteria) {
    let sortFunction = {
        asc: function (arr) {
            return arr.sort((a, b) => a - b);
        },
        desc: function (arr) {
            return arr.sort((a, b) => b - a);
        }
    }

    let func = sortFunction[criteria];
    return func(input);
}

solve([14, 7, 17, 6, 8], 'asc')
solve([14, 7, 17, 6, 8], 'desc')

function solve(array, criteria) {
    criteria === 'asc' ? array.sort((a, b) => a - b) : array.sort((a, b) => b - a);
    return array;
}
solve([14, 7, 17, 6, 8], 'asc')
solve([14, 7, 17, 6, 8], 'desc')