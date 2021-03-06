function solve(input) {
    let dashboard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let player = 'X';
    let win = false;
    let counter = 1;

    input.forEach(line => {
        let [row, col] = line.split(' ').map(num => Number(num));
        if (!win && counter < 10) {
            if (!dashboard[row][col]) {
                dashboard[row][col] = player;

                counter++;

                if (checkForWinner(dashboard, player)) {
                    win = true;
                    return;
                }

                player = player === 'X' ? 'O' : 'X';
            } else {
                console.log('This place is already taken. Please choose another!');
            }
        }
    });

    if (win) {
        console.log(`Player ${player} wins!`);
    } else {
        console.log('The game ended! Nobody wins :(');
    }

    printMatrix(dashboard);

    function checkForWinner(dashboard, sign) {
        let isWinner = false;

        for (let i = 0; i < 3; i++) {

            if (dashboard[i][0] === sign &&
                dashboard[i][1] === sign &&
                dashboard[i][2] === sign) {

                isWinner = true;
                break;
            }

            if (dashboard[0][i] === sign &&
                dashboard[1][i] === sign &&
                dashboard[2][i] === sign) {

                isWinner = true;
                break;
            }
        }

        if (!isWinner) {
            if ((dashboard[0][0] === sign && dashboard[1][1] === sign && dashboard[2][2] === sign) ||
                (dashboard[2][0] === sign && dashboard[1][1] === sign && dashboard[0][2] === sign)) {

                isWinner = true;
            }
        }

        return isWinner;
    };

    function printMatrix(dashboard) {
        dashboard.forEach((row) => {
            console.log(row.join('\t'));
        });
    }
};

solve(['0 1', '0 0', '0 2', '2 0', '1 0', '1 1', '1 2', '2 2', '2 1', '0 0']);
solve(['0 0', '0 0', '1 1', '0 1', '1 2', '0 2', '2 2', '1 2', '2 2', '2 1']);
solve(['0 1', '0 0', '0 2', '2 0', '1 0', '1 2', '1 1', '2 1', '2 2', '0 0']);
