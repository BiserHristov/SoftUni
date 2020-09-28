function CappyJuice(input) {
    let fruits = {};
    let result = {};

    for (let index = 0; index < input.length; index++) {
        let element = input[index];
        let [juice, quantity] = element.split('=>').map(x => x.trim());
        quantity = Number(quantity) / 1000;

        if (fruits[juice]) {
            fruits[juice] += quantity;
        }
        else {
            fruits[juice] = quantity;
        }

        if (fruits[juice] >= 1) {
            let bottles = Math.floor(fruits[juice]);

            fruits[juice] = Math.round((fruits[juice] - bottles) * 1000) / 1000;

            if (result[juice]) {
                result[juice] += bottles;
            }
            else {
                result[juice] = bottles;
            }
        }

    }

    for (const fruit of Object.keys(result)) {
        console.log(`${fruit} => ${result[fruit]}`)
    }
}


CappyJuice([
    'Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
])


CappyJuice([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
])
