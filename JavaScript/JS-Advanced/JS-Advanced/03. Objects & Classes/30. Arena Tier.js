function solve(input) {
    let list = {};

    for (let el of input) {
        if (el === 'Ave Cesar') {
            break;
        } else if (el.includes(' -> ')) {
            add(el);
        } else {
            battle(el);
        }
    }

    let tier = Object.entries(list)
    let array = [];

    for (let el of tier) {
        let name = el[0];
        let pow = Object.entries(el[1]);
        let sum = pow.map(a => a[1]).reduce((a, b) => a + b);

        array.push([name, pow, sum]);
    }

    array.sort((a, b) => b[2] - a[2] || a[0].localeCompare(b[0]));

    for (let part of array) {
        console.log(`${part[0]}: ${part[2]} skill`);

        part[1].sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0]))
            .map(x => console.log(`- ${x[0]} <!> ${x[1]}`));
    }


    function add(el) {
        let [gladiator, skill, powerAsStr] = el.split(' -> ');
        let power = Number(powerAsStr);

        if (!list.hasOwnProperty(gladiator)) {
            list[gladiator] = {};
            list[gladiator][skill] = power;

        } else {
            if (!list[gladiator].hasOwnProperty(skill)) {
                list[gladiator][skill] = power;

            } else {
                let oldPower = list[gladiator][skill];
                if (power > oldPower) {
                    list[gladiator][skill] = power;
                }
            }
        }
    }

    function battle(el) {
        let [gladiatorA, gladiatorB] = el.split(' vs ');

        if (list.hasOwnProperty(gladiatorA) && list.hasOwnProperty(gladiatorB)) {
            let skillA = list[gladiatorA];
            let skillB = list[gladiatorB];

            for (let elA in skillA) {
                for (let elB in skillB) {
                    if (elA === elB) {
                        if (skillA[elA] > skillB[elB]) {
                            delete list[gladiatorB];
                        } else if (skillA[elA] < skillB[elB]) {
                            delete list[gladiatorA];
                        }
                    }
                }
            }
        }
    }
}

solve([
    `Pesho -> BattleCry -> 400`,
    `Gosho -> PowerPunch -> 300`,
    `Stamat -> Duck -> 200`,
    `Stamat -> Tiger -> 250`,
    `Ave Cesar`,]
)
console.log(`--------------------------------------------------`)
solve([
    `Pesho -> Duck -> 400`,
    `Julius -> Shield -> 150`,
    `Gladius -> Heal -> 200`,
    `Gladius -> Support -> 250`,
    `Gladius -> Shield -> 250`,
    `Pesho vs Gladius`,
    `Gladius vs Julius`,
    `Gladius vs Gosho`,
    `Ave Cesar`,]
)


function solve1(input) {
    let obj = {};

    for (const line of input) {
        if (line === 'Ave Cesar') {
            break;
        }

        let element = line.split(' ');

        if (element[1] === '->') {
            let theLine = line.split(' -> ');
            let gladiator = theLine[0];
            let technique = theLine[1];
            let skillAmount = Number(theLine[2]);

            if (!obj.hasOwnProperty(gladiator)) {
                obj[gladiator] = {};
            }
            if (!obj[gladiator].hasOwnProperty(technique)
                || obj[gladiator][technique] < skillAmount) {
                obj[gladiator][technique] = skillAmount;
            }
        } else if (element[1] === 'vs') {
            let theLine = line.split(' vs ');
            let gladiator1 = theLine[0];
            let gladiator2 = theLine[1];

            if (obj.hasOwnProperty(gladiator1)
                && obj.hasOwnProperty(gladiator2)) {
                let gladiator1Techniques = (obj[gladiator1]);
                let gladiator2Techniques = (obj[gladiator2]);
                
                for (const key in gladiator1Techniques) {

                    if (gladiator2Techniques.hasOwnProperty(key)) {
                        if (gladiator1Techniques[key] > gladiator2Techniques[key]) {
                            delete obj[gladiator2];
                        } else if (gladiator1Techniques[key] < gladiator2Techniques[key]) {
                            delete obj[gladiator1];
                        }
                    }
                }
            }
        }
    }
    for (const key in obj) {
        let sum = 0;
        let outsideObj = obj[key];
        for (const insideKey in outsideObj) {
            sum += outsideObj[insideKey];
        }
        outsideObj['sum'] = sum;
    }

    Object.entries(obj)
        .sort((a, b) => b[1].sum - a[1].sum || a[0].localeCompare(b[0]))
        .forEach(element => {
            console.log(`${element[0]}: ${element[1].sum} skill`);
            delete element[1].sum;
            Object.entries(element[1])
                .sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0]))
                .forEach(element => {
                    console.log(` - ${element[0]} <!> ${element[1]}`);
                });
        });
}

solve1([
    `Pesho -> BattleCry -> 400`,
    `Gosho -> PowerPunch -> 300`,
    `Stamat -> Duck -> 200`,
    `Stamat -> Tiger -> 250`,
    `Ave Cesar`,]
)
console.log(`--------------------------------------------------`)
solve1([
    `Pesho -> Duck -> 400`,
    `Julius -> Shield -> 150`,
    `Gladius -> Heal -> 200`,
    `Gladius -> Support -> 250`,
    `Gladius -> Shield -> 250`,
    `Pesho vs Gladius`,
    `Gladius vs Julius`,
    `Gladius vs Gosho`,
    `Ave Cesar`,]
)