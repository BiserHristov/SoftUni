function AutoEngineeringCompany(input) {
    let result = {};
    for (let i = 0; i < input.length; i++) {
        let [brand, model, quantity] = input[i].split(' | ');
        quantity = Number(quantity);

        if (!result[brand]) {
            result[brand] = {};
            result[brand][model] = 0;

        } else if (!result[brand][model]) {
            result[brand][model] = 0
        }

        result[brand][model] += quantity;

    }


    for (let i = 0; i < Object.keys(result).length; i++) {
        let currentBrand = Object.keys(result)[i];
        let cars = result[currentBrand];

        console.log(currentBrand);

        for (let index = 0; index < Object.keys(cars).length; index++) {
            const currentCar = Object.keys(cars)[index];
            console.log(`###${currentCar} -> ${cars[currentCar]}`);
       }
        
    }

}

AutoEngineeringCompany([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
])

