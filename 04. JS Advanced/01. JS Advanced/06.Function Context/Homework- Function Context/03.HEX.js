class Hex {

    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(number) {

        if (this.isHex(number)) {
            number = parseInt(number, 16);
        }

        return (this.value + number).toString(16).toUpperCase();
        //return new Hex(this.value + number)
    }

    minus(number) {

        // if (this.isHex(number)) {
        //     number = parseInt(number, 16);
        // }

        //return `0x${((this.value - number).toString(16)).toUpperCase()}`;
        return new Hex(this.value - number)


    }

    parse(string) {
        return parseInt(string, 16);
    }



    isHex(num) {
        return Boolean(num.toString().match(/^0x[0-9a-f]+$/i))
    }

}







let FF = new Hex(255);
console.log(FF.parse('0xFF'))
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');
