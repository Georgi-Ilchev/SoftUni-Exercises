function solve(n, k) {
    let result = [1];

    for (let i = 1; i < n; i++) {
        let lastKElements = result.slice(-k);
        let sum = lastKElements.reduce((a, x) => a + x, 0);

        result.push(sum);
    }

    console.log(result.join(' '));
};
// solve(6, 3);
// solve(8, 2);


function lastKNumbers(n, k) {
    let result = [1];

    for (let i = 1; i < n; i++) {
        let lastKelements = result.slice(-k);
        let sum = lastKelements.reduce((a, x) => a + x, 0);

        result.push(sum);
    }
    return result;
}

lastKNumbers(6, 3)