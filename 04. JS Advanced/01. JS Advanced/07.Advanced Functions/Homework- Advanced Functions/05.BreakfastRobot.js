function solution() {

    let meals = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        },

    }

    let warehouse = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0

    }

    let makeOrder = {
        restock: function (microelement, quantity) {
            warehouse[microelement] += quantity;
            return "Success";
        },
        report: function () {
            let result = [];
            Object.entries(warehouse).forEach(([key, value]) => {
                result.push(`${key}=${value}`)
            })

            return result.join(' ')
        },

        prepare: function (product, count) {
            let message = '';

            Object.entries(meals[product]).forEach(([el, neededQuantity]) => {
                if (warehouse[el] < neededQuantity * count) {
                    message= `Error: not enough ${el} in stock`
                    break;
                }
            })

            return message;

        }

    }

    return function (input) {
        let [command, subcommand, qty] = input.split(' ')

        return makeOrder[command](subcommand, Number(qty));
    }

}

let manager = solution();
console.log(manager("restock flavour 50"));  // Success

console.log(manager("prepare lemonade 4"))

