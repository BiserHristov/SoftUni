class Stringer {
    #origString;
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
        this.#origString = innerString;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if (this.innerLength - length <= 0) {
            this.innerLength = 0
        } else {
            this.innerLength -= length;
        }

    }

    toString() {
        if (this.#origString.length <= this.innerLength) {
            return this.#origString;
        } else if (this.innerLength == 0)
        {
            return '...';
        }else {
            return this.#origString.slice(0,this.innerLength)+'...'
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
