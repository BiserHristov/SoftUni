(function () {
    Object.defineProperty(String.prototype, 'ensureStart', {
        value(word) {
            let result = this;
            if (this.startsWith(word)) {
                console.log(`\'${word}\' already present`);
            }
            else {

                result = word + this;
            }

            return result;
        }
    });

    Object.defineProperty(String.prototype, 'ensureEnd', {
        value(word) {
            let result = this;
            if (this.endsWith(word)) {
                console.log(`\'${word}\' already present`);
            }
            else {

                result = this + word;
            }

            return result;
        }
    });

    Object.defineProperty(String.prototype, 'isEmpty', {
        value() {
            return this.length == 0
        }
    });

})();


let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.ensureEnd('string');
str='';
console.log(str.isEmpty());
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');
