function solve(matrix) {
    let sumRow = row => matrix[row].reduce((a, b) => a + b);
    let sumCol = col => matrix.map(row => row[col]).reduce((a, b) => a + b);

    if (matrix.length > 0) {
        let targetSum = sumRow(0);

        for (let row = 1; row < matrix.length; row++) {
            let rowSum = sumRow(row);
            if (rowSum !== targetSum) {
                return false;
            }
        }

        for (let col = 0; col < matrix[0].length; col++) {
            let colSum = sumCol(col);
            if (colSum !== targetSum) {
                return false;
            }
        }
    }

    return true;
};

console.log(solve(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
));

console.log(solve(
    [[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
));

console.log(solve(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
));

function magicMatrices(matrix) {
    let rowSum = row => matrix[row].reduce((a, b) => a + b);
    let colSum = col => matrix.map(row => row[col]).reduce((a, b) => a + b);

    if (matrix.length > 0) {
        let targetSum = rowSum(0);

        for (let row = 1; row < matrix.length; row++) {
            let sumRow = rowSum(row);
            if (sumRow !== targetSum) {
                return false;
            }
        }

        for (let col = 0; col < matrix[0].length; col++) {
            let sumCol = colSum(col);
            if (sumCol !== targetSum) {
                return false;
            }
        }
    }

    return true;
}