const {
    assert
} = require('chai');


const classStrBuilder = require('../src/stringBuilder');

// new string
let string = new classStrBuilder('hello');
let emptyString = new classStrBuilder();



describe('Testing if class instance returns the correct output', () => {
    describe('Testing string verifier', () => {
        it('should return an error if passed parameter is not a string', () => {
            assert.throw(() => {
                new classStrBuilder({});
            }, 'Argument must be string')
        })
    })


    describe('testing constructor', () => {
        it('should return a string if toString is called', () => {
            assert.equal(string.toString(), 'hello')
        })
        it('should return an empty string if toString if instance is an empty array', () => {
            assert.equal(emptyString.toString(), '')
        })
        it('should add a passed parameter string to the end of the string', () => {
            string.append(', my lovely')
            assert.equal(string.toString(), 'hello, my lovely')
        })
        it('should add a passed parameter string to the begining of the string', () => {
            string.prepend('Oh, well - ')
            assert.equal(string.toString(), 'Oh, well - hello, my lovely')
        })
        it('should add a passed parameter string at the passed index', () => {
            string.insertAt(', who do we see here', 8)
            assert.equal(string.toString(), 'Oh, well, who do we see here - hello, my lovely')
        })
        it('should remove elements from the passed start to the passed end parameter', () => {
            string.remove(0, 10)
            assert.equal(string.toString(), 'who do we see here - hello, my lovely')
        })
       
    })


})