let { assert } = require('chai');
let { lookupChar } = require('./charLookup.js')

describe('Task03. CharLookup', () => {
    it('should return undefined when first parameter is not string', () => {
        assert.equal(undefined, lookupChar(6, 10));
    })

    it('should return undefined when second parameter is not a number', () => {
        assert.equal(undefined, lookupChar('Pesho', 'Ivanov'));
    })

    it('should return "Incorrect index" when second parameter is greater than length of first parameter', () => {
        assert.equal('Incorrect index', lookupChar('Pesho', 5));
    })

    it('should return "Incorrect index" when second parameter is number less than 0', () => {
        assert.equal('Incorrect index', lookupChar('Pesho', -1));
    })

    it('should return the char at index of a string when input is valid', () => {
        assert.equal('s', lookupChar('Pesho', 2))
    })
})