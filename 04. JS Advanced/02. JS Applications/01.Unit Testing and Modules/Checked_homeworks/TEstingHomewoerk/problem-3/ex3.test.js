const assert = require('chai').assert;
const app = require('./ex3');

describe('Tests for exercise 3', () => {
    it('Should return undefined if string in not type of string', () => {
        assert.equal(undefined, app(2, 2));
    });

    it('Should return undefined if index in not type of number', () => {
        assert.equal(undefined, app(2, []));
    });

    it('Should return "Incorrect index" if string.length <= index', () => {
        assert.equal('Incorrect index', app('test', 5));
    });

    it('Should return "Incorrect index" if index < 0', () => {
        assert.equal('Incorrect index', app('test', -1));
    });

    it('Should return "e"', () => {
        assert.equal('e', app('test', 1));
    });
})