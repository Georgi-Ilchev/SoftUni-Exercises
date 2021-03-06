function solve(arrayKingdoms, fights) {

    let kingdoms = {};
    for (let element of arrayKingdoms) {
        let kingdom = element.kingdom;
        let general = element.general;
        let army = +element.army;

        if (!kingdoms.hasOwnProperty(kingdom)) {
            kingdoms[kingdom] = {
                [general]: { army, wins: 0, losses: 0 }
            };
        } else {
            if (kingdoms[kingdom].hasOwnProperty([general])) {
                kingdoms[kingdom][general].army += army;
            } else {
                kingdoms[kingdom][general] = {
                    army,
                    wins: 0,
                    losses: 0,
                }
            }
        }
    }

    for (let element of fights) {
        let attackingKingdom = element[0];
        let attackingGeneral = element[1];
        let defendingKingdom = element[2];
        let defendingGeneral = element[3];

        let armyAttack = 0;
        let armyDeffend = 0;

        if (kingdoms.hasOwnProperty(attackingKingdom) && kingdoms.hasOwnProperty(defendingKingdom)) {
            if (kingdoms[attackingKingdom] === kingdoms[defendingKingdom]) {
                continue;
            }
            if (kingdoms[attackingKingdom].hasOwnProperty(attackingGeneral) &&
                kingdoms[defendingKingdom].hasOwnProperty(defendingGeneral)) {

                armyAttack = kingdoms[attackingKingdom][attackingGeneral].army;
                armyDeffend = kingdoms[defendingKingdom][defendingGeneral].army;
            }
        }

        if (armyAttack > armyDeffend) {
            kingdoms[attackingKingdom][attackingGeneral].army = Math.floor(armyAttack + armyAttack * 0.1);
            kingdoms[defendingKingdom][defendingGeneral].army = Math.floor(armyDeffend - armyDeffend * 0.1);

            kingdoms[attackingKingdom][attackingGeneral].wins += 1;
            kingdoms[defendingKingdom][defendingGeneral].losses += 1;
        } else if (armyAttack < armyDeffend) {
            kingdoms[attackingKingdom][attackingGeneral].army = Math.floor(armyAttack - armyAttack * 0.1);
            kingdoms[defendingKingdom][defendingGeneral].army = Math.floor(armyDeffend + armyDeffend * 0.1);

            kingdoms[attackingKingdom][attackingGeneral].losses += 1;
            kingdoms[defendingKingdom][defendingGeneral].wins += 1;
        }
    }

    let orderedKingdoms = Object.keys(kingdoms).sort((a, b) =>
        getTotal(kingdoms[b], 'wins') - getTotal(kingdoms[a], 'wins') ||
        getTotal(kingdoms[a], 'losses') - getTotal(kingdoms[b], 'losses') ||
        a.localeCompare(b)
    );


    let winner = orderedKingdoms[0];
    console.log(`Winner: ${winner}`);

    let generals = Object.keys(kingdoms[winner]).sort((a, b) => kingdoms[winner][b].army - kingdoms[winner][a].army);
    generals.forEach(general => {
        let info = kingdoms[winner][general];
        console.log(`/\\general: ${general}`);
        console.log(`---army: ${info.army}`);
        console.log(`---wins: ${info.wins}`);
        console.log(`---losses: ${info.losses}`);
    })

    function getTotal(kingdom, type) {
        return Object.keys(kingdom).reduce((acc, cur) => (acc + kingdom[cur][type]), 0);
    }
}

solve([
    { kingdom: "Maiden Way", general: "Merek", army: 5000 },
    { kingdom: "Stonegate", general: "Ulric", army: 4900 },
    { kingdom: "Stonegate", general: "Doran", army: 70000 },
    { kingdom: "YorkenShire", general: "Quinn", army: 0 },
    { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
    { kingdom: "Maiden Way", general: "Berinon", army: 100000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Stonegate", "Ulric", "Stonegate", "Doran"],
    ["Stonegate", "Doran", "Maiden Way", "Merek"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"],
    ["Maiden Way", "Berinon", "Stonegate", "Ulric"]]
)

console.log(`--------------------------------------------------------------`)

solve([
    { kingdom: "Stonegate", general: "Ulric", army: 5000 },
    { kingdom: "YorkenShire", general: "Quinn", army: 5000 },
    { kingdom: "Maiden Way", general: "Berinon", army: 1000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Maiden Way", "Berinon", "YorkenShire", "Quinn"]]
)

console.log(`--------------------------------------------------------------`)

solve([
    { kingdom: "Maiden Way", general: "Merek", army: 5000 },
    { kingdom: "Stonegate", general: "Ulric", army: 4900 },
    { kingdom: "Stonegate", general: "Doran", army: 70000 },
    { kingdom: "YorkenShire", general: "Quinn", army: 0 },
    { kingdom: "YorkenShire", general: "Quinn", army: 2000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Doran"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"]]
)