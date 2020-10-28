let { assert } = require('chai');
let StringBuilder = require('./stringBuilder')

describe('05. StringBuilder tests:', () => {
    let sb;
    beforeEach(() => {
        sb = new StringBuilder();
    })

    describe('Constructor tests:', () => {
        it('When input is empty, length of array should be 0', () => {
            assert.equal(0, sb.toString().length)
        })

        it('When input is not of type string, whould return error message', () => {
            assert.throw(() => new StringBuilder(5), 'Argument must be string')
        })

        it('When input is valid string, length of array should be ==length od string', () => {
            sb = new StringBuilder('hello')
            assert.equal(5, sb.toString().length)
        })
    })

    describe('append tests:', () => {
        it('When input is not of type string, whould return error message', () => {
            assert.throw(() => sb.append(66), 'Argument must be string')
        })

        it('When input (Pesho) is valid, array should be valid(Pesho)', () => {
            sb.append('Pesho')
            assert.equal('P', sb.toString()[0])
            assert.equal('e', sb.toString()[1])
            assert.equal('s', sb.toString()[2])
            assert.equal('h', sb.toString()[3])
            assert.equal('o', sb.toString()[4])
        })

    })

    describe('prepend tests:', () => {
        it('When input is not of type string, whould return error message', () => {
            assert.throw(() => sb.prepend(66), 'Argument must be string')
        })

        it('When input (Pesho) is valid, array should be valid(Pesho)', () => {
            sb.prepend('Pesho')
            assert.equal('P', sb.toString()[0])
            assert.equal('e', sb.toString()[1])
            assert.equal('s', sb.toString()[2])
            assert.equal('h', sb.toString()[3])
            assert.equal('o', sb.toString()[4])
        })

    })

    describe('insertAt tests:', () => {
        it('When first parameter is not of type string, whould return error message', () => {
            assert.throw(() => sb.insertAt(33, 6), 'Argument must be string')
        })

        it('When input (cd) is valid, array should be valid(abcdef)', () => {
            sb.append('abef')
            sb.insertAt('cd', 2)

            assert.equal('abcdef', sb.toString())
        })

    })

    describe('remove tests:', () => {
        it('When input is valid, array should be valid', () => {
            sb.append('abcdef')
            sb.remove(2, 2)

            assert.equal('abef', sb.toString())
        })

    })

    describe('toString() tests:', () => {
        it('When input is valid, array should be valid', () => {
            sb.append('abcdef')
            sb.remove(2, 2)

            assert.equal('abef', sb.toString())
        })

    })


})