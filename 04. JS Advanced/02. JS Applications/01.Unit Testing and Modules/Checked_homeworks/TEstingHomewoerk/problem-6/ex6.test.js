const assert = require('chai').assert;
const StringBuilder = require('./ex6');

describe('Tests for exercise 6', () => {

    let sb;
    beforeEach(() => {
        sb = new StringBuilder();
    });

    describe('verifyParams', () => {
        it('Should throw an Error if param is not a string', () => {
            assert.throw(() => {
                new StringBuilder({});
            }, 'Argument must be string');
        })
    });

    describe('constructor', () => {
        it('Should work with empty param', () => {
            assert.equal('', sb.toString());
        });

        it('Should work with string', () => {
            sb = new StringBuilder('string');
            
            assert.equal('string', sb.toString());
        })
    });

    describe('append', () => {
        it('Should add the text in the end of the array', () => {
            sb.append('text');
            assert.equal('text', sb.toString());
        });
    });

    describe('prepend', () => {
        it('Should add the text in the start of the array', () => {
            sb.append('ext');
            sb.prepend('t');
            assert.equal('text', sb.toString());
        });
    });

    describe('insertAt', () => {
        it('Should add the text in the current index of the array', () => {
            sb.append('xt');
            sb.insertAt('te', 0);
            assert.equal('text', sb.toString());
        });
    });

    describe('remove', () => {
        it('Should remove the text in the current index with current length of the array', () => {
            sb.append('tasdext');
            sb.remove(1, 3);
            assert.equal('text', sb.toString());
        });
    });

    describe('toString', () => {
        it('Should print the correct array', () => {
            sb.append('text');
            assert.equal('text', sb.toString());
        });
    });
})