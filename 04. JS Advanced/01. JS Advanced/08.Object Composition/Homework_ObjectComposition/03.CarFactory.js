function solve(input) {
    let storage = {
        engine: [
            { carPower: 90, volume: 1800 },
            { carPower: 120, volume: 2400 },
            { carPower: 200, volume: 3500 }
        ],
        carriage: {
            hatchback: { type: 'hatchback', color: '' },
            coupe: { type: 'coupe', color: '' }
        },
        wheels: []
    }

    let car = {};

    let { model, power, color, carriage, wheelsize } = input;

    //set model
    car.model = model;

    let engines = storage.engine;
    for (let index = 0; index < engines.length; index++) {
        const engine = engines[index];
        let { carPower, volume } = engine;
        if (carPower >= power) {
            //set engine
            car.engine = {
                power: carPower,
                volume
            }
            break;

        }
    }

    //set carriage
    car.carriage = { type: carriage, color }
    let wSize = parseInt(wheelsize);

    if (wSize % 2 == 0) {
        wSize--;
    }

    car.wheels = [];
    for (var index = 0; index < 4; index++) {
        //set wheels
        car.wheels.push(wSize);
    }

    return car;

}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}))



console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}))