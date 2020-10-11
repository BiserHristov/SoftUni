function solve() {

    let types = [];
    let counts = {};

    [...arguments].forEach(item => {
        if (!counts[typeof item]) {
            counts[typeof item] = 0;

        }
        counts[typeof item]++;;

        let itemType = typeof item;
        let obj = { itemType, value: item };
        types.push(obj);
    });

    types.forEach(el => console.log(`${el.itemType}: ${el.value}`))

    Object.entries(counts)
    .sort((curr, next) => {
        return next[1] - curr[1];
    })
    .forEach(([type, count]) => {
            console.log(`${type} = ${count}`);
        })

}



//solve('cat', 42, function () { console.log('Hello world!'); })
solve(42, 'cat', 15, 'kitten', 'tomcat')
