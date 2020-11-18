const assert = require('chai').assert;
const app = require('./ex4');

describe('Tests for exrcise 4', () => {
    describe('addFive function', () => {
        it('Should return undefined if param is not a number', () => {
            assert.equal(undefined, app.addFive('string'));
        });

        it('Should return correct answer', () => {
            assert.equal(10, app.addFive(5));
        });
    });

    describe('subtractTen function', () => {
        it('Should return undefined if param is not a number', () => {
            assert.equal(undefined, app.subtractTen('string'));
        });

        it('Should return correct answer', () => {
            assert.equal(20, app.subtractTen(30));
        });
    });

    describe('sum function', () => {
        it('Should return undefined if first param is not a number', () => {
            assert.equal(undefined, app.sum('string', 2));
        });

        it('Should return undefined if second param is not a number', () => {
            assert.equal(undefined, app.sum(2, 'string'));
        });

        it('Should return correct answer', () => {
            assert.equal(15, app.sum(5, 10));
        })
    })
})