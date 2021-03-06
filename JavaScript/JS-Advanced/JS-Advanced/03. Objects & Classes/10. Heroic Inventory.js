function solve(input) {
    let result = [];

    input.forEach(line => {
        let [name, levelAsString, items] = line.split(' / ');
        level = Number(levelAsString);

        items = items ? items.split(', ') : [];

        let hero = { name, level, items };
        result.push(hero);
    });
    console.log(JSON.stringify(result));
}


solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
);

solve(['Jake / 1000 / Gauss, HolidayGrenade']);