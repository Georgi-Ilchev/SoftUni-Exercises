function solve(matrix) {
    matrix = matrix.map(row => row.split(' ').map(Number));

    let firstDiagonalSum = matrix.map((row, rowIndex) =>
        row.filter((e, colIndex) => rowIndex === colIndex))
        .reduce((a, b) => Number(a) + Number(b));

    let secondDiagonalSum = matrix.map((row, rowIndex) =>
        row.filter((e, colIndex) => colIndex === row.length - 1 - rowIndex))
        .reduce((a, b) => Number(a) + Number(b));

    let isEqual = (row, col) => row === col || col === matrix[row].length - 1 - row;

    firstDiagonalSum !== secondDiagonalSum
        ? console.log(matrix.map(row => row.join(' ')).join('\n'))
        : console.log(matrix.map((row, rowIndex) => row.map((e, colIndex) => isEqual(rowIndex, colIndex)
            ? e
            : firstDiagonalSum).join(' ')).join('\n'));
};

solve(
    ['5 3 12 3 1',
        '11 4 23 2 5',
        '101 12 3 21 10',
        '1 4 5 2 2',
        '5 22 33 11 1']
);

solve(
    ['1 1 1',
        '1 1 1',
        '1 1 0']
);