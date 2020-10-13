function solve() {
    let array = [];

    //WORKS TOO!
    //let arrSize=0;

    let result = {
        add,
        remove,
        get,
        size: 0
        //get size () {return arrSize}
    }

    return result;
    function add(num) {
        let index = array.findIndex(n => n > num);

        if (index < 0) {
            array.push(num)
        } else if (index == 0) {
            array.splice(0, 0, num);
        } else {
            array.splice(index, 0, num);
        }

        this.size++;
        //arrSize++;

        return array;
    }
    function remove(index) {
        if (index < 0 || index >= array.length) {
            throw new Error();
        }

        array.splice(index, 1);
        this.size--;
        //arrSize--;

        return array;
    }
    function get(index) {
        if (index < 0 || index >= array.length) {
            throw new Error();
        }

        return array[index];
    }

}




// let arr = solve();
// arr.add(5);
// arr.add(3);
// arr.add(8);
// arr.remove(1);
// console.log(arr.size)
