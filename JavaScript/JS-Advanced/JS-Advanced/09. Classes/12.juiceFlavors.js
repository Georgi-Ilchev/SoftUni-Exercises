function juiceFlavors(input) {
    let juices = {};
    let bottles = {};

    input.forEach(el => {
        let [name, quantity] = el.split(' => ');

        if (!juices[name]) {
            juices[name] = Number(quantity);
        } else {
            juices[name] += Number(quantity);
        }

        while (juices[name] >= 1000) {
            juices[name] -= 1000;

            if (!bottles[name]) {
                bottles[name] = 1;
            } else {
                bottles[name]++;
            }
        }
    });

    let result = '';

    for (const [key, value] of Object.entries(bottles)) {
        result += `${key} => ${value}\n`;
    }

    return result;
}

juiceFlavors(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
)