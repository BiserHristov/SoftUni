function StoreCatalogue(input) {
    let result = {};

    for (let index = 0; index < input.length; index++) {
        const element = input[index];
        let [name, price] = element.split(' : ');
        price = Number(price);
        if (!result[name[0]]) {
            result[name[0]] = [];

        }
        let product = { name, price };
        result[name[0]].push(product)
    }

    let sortedByLetter = Object.entries(result).sort((curr, next) => curr[0].localeCompare(next[0]))
    
    for (var i = 0; i < sortedByLetter.length; i++) {
        console.log(sortedByLetter[i][0]);

        let orderedByName=sortedByLetter[i][1].sort((curr, next) => curr.name.localeCompare(next.name));
        orderedByName.forEach(el=> {
            console.log(`  ${el.name}: ${el.price}`)})
    }

   
}
StoreCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]
)

StoreCatalogue([
    'Banana : 2',
    "Rubic's Cube : 5",
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'
]
)


//  //Works too!

//  function StoreCatalogue(input) {
//     let result = {};

//     for (let index = 0; index < input.length; index++) {
//         const element = input[index];
//         let [product, price] = element.split(' : ');
//         price = Number(price);
//         result[product] = price;
//         //console.log(product, price)
//     }

//     let ordered = {};
//     Object.keys(result).sort().forEach(k => ordered[k] = result[k]);
//     let letter = '';
//     for (let index = 0; index < Object.keys(ordered).length; index++) {
//         const element = Object.keys(ordered)[index];
//         if (index === 0) {
//             letter = element[0];
//             console.log(letter);
//             console.log(`  ${element}: ${ordered[element]}`)
//         } else {
//             if (element[0]!= letter) {
//                 letter = element[0];
//                 console.log(letter);
//             }

            
//             console.log(`  ${element}: ${ordered[element]}`)
//         }
//     }

// }