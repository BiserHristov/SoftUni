const assert = require('chai').assert;
const app = require('./ex2');

describe('Tests for exercise 2', () => {
    it('Should return undefined if not a string', () => {
        let num = 2;

        let result = app(num);

        assert.equal(undefined, result);
    });

    it('Should return even', () => {
        assert.equal('even', app('da'));
    });

    it('Should return odd', () => {
        assert.equal('odd', app('asd'))
    });
})