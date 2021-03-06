function solve(rows, cols) {
    let matrix = createMatrix();
    fillMatrix();

    console.log(matrix.map(row => row.join(' ')).join('\n'));

    function fillMatrix(currentValue = 1, startIndex = 0) {

        //from left to right
        for (let i = startIndex; i < matrix[startIndex].length - startIndex; i++) {
            matrix[startIndex][i] = currentValue++;
        }

        //from top to bottom
        for (let i = startIndex + 1; i < matrix.length - startIndex; i++) {
            matrix[i][matrix[i].length - 1 - startIndex] = currentValue++;
        }

        //from right to left
        for (let i = matrix.length - 2 - startIndex; i > startIndex; i--) {
            matrix[matrix.length - 1 - startIndex][i] = currentValue++;
        }

        //from bottom to top
        for (let i = matrix.length - 1 - startIndex; i > startIndex; i--) {
            matrix[i][startIndex] = currentValue++;
        }

        if (currentValue <= matrix.length * matrix[0].length) {
            startIndex++;
            fillMatrix(currentValue, startIndex);
        }
    }

    function createMatrix() {
        let matrix = [];

        for (let index = 0; index < rows; index++) {
            matrix.push(new Array(cols));
        }

        return matrix;
    }
};

solve(5, 5);
solve(3, 3);
