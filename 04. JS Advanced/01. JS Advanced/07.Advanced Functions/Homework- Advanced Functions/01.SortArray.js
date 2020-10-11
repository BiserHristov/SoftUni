function solve(arr, criteria) {

    let sortLogic = {
        asc: function (arr) {
            return arr.sort((curr, next) => { return Number(curr) - Number(next) })
        },
        desc: function (arr) {
            return arr.sort((curr, next) => { return Number(next) - Number(curr) })
        }
    }

    return sortLogic[criteria](arr);

}

console.log(solve([14, 7, 17, 6, 8], 'asc'))
console.log(solve([14, 7, 17, 6, 8], 'desc'))

// [ 6, 7, 8, 14, 17 ]
// [ 17, 14, 8, 7, 6 ]