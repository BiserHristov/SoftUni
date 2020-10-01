class List {

    constructor() {
        this.data = [];
        this.size=0;
    }

    

    add(element) {
        this.data.push(element)
        this.data.sort((a, b) => a - b);
        this.size++;

    }

    remove(index) {
        this._validateIndex(index);
        this.data.splice(index, 1);
        this.size--;
    }


    get(index) {
        this._validateIndex(index);
        return this.data[index];

    }

    _validateIndex(index) {
        if (index < 0 || index >= this.data.length) {
            throw new Error("Invalide index")
        }
    }

}


let myList = new List();
myList.add(5);
myList.add(3);
myList.remove(0);
console.log(myList.get(0));
console.log(myList.size);