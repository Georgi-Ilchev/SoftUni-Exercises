function carFactory(input) {
    const result = {};
    function getEngine(power) {
        if (power <= 90) {
            return { power: 90, volume: 1800 };
        } else if (power <= 120) {
            return { power: 120, volume: 2400 };
        } else {
            return { power: 200, volume: 3500 };
        }
    }

    const properWheelSize = input.wheelsize % 2 == 0 ? input.wheelsize - 1 : input.wheelsize;

    result.model = input.model;
    result.engine = getEngine(input.power);
    result.carriage = { type: input.carriage, color: input.color };
    result.wheels = new Array(4).fill(properWheelSize, 0, 4);

    return result;
}

carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
})