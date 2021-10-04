function solve(input) {
    let result = [];

    for (let commands of input) {

        //1
        let [command, value] = commands.split(' ');

        switch (command) {
            case 'add':
                result.push(value);
                break;
            case 'remove':
                result = result.filter(x => x !== value);
                break;
            case 'print':
                console.log(result.join(","));
                break;
            default:
                break;
        }

        //2
        // let command = commands.split(' ')[0];

        // if (command === 'print') {
        //     console.log(result.join(","));
        // }
        // else {
        //     let value = commands.split(' ')[1];

        //     if (command === 'add') {
        //         result.push(value);
        //     } else if (command === 'remove') {
        //         result = result.filter(x => x !== value);
        //     }
        // }
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);