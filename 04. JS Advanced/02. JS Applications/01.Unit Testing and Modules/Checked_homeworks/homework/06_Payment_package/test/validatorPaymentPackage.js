const chai = require('chai').assert;

const {
    assert
} = require('chai');
const importedModule = require('../src/paymentPackage');

let newPackage = new importedModule('HR Services', 1500);
describe('Testing Payment package functionality', () => {
    describe('testing constructor', () => {
        it('should throw an error if an empty string is passed', () => {
            assert.throw(() => {
                new importedModule('', 100);
            }, 'Name must be a non-empty string')
        })
        it('should throw an error if the passed parameter is not a string', () => {
            assert.throw(() => {
                new importedModule(100, 100);
            }, 'Name must be a non-empty string')
        })
        it('should throw an error if the passed second parameter is not a number', () => {
            assert.throw(() => {
                new importedModule('HR Serv', 'a');
            }, 'Value must be a non-negative number')
        })
        it('should throw an error if the passed second parameter is below zero', () => {
            assert.throw(() => {
                new importedModule('HR Serv', -15);
            }, 'Value must be a non-negative number')
        })
    })

    describe('testing NAME method', () => {
        it('should return the instance name', () => {
            assert.equal(newPackage.name, 'HR Services')
        })
        it('should set a new name for the instance', () => {
            newPackage.name = 'RD Services'
            assert.equal(newPackage.name, 'RD Services')
        })
    })
    describe('testing the VALUE method', () => {
        it('should return the instance value', () => {
            assert.equal(newPackage.value, 1500)
        })
        it('should set a new value for the instance', () => {
            newPackage.value = 3300
            assert.equal(newPackage.value, 3300)
        })
    })
    describe('testing the VAT accessor', () => {
        it('should return the instance VAT', () => {
            assert.equal(newPackage.VAT, 20)
        })
        it('should set a new VAT for the instance', () => {
            newPackage.VAT = 33
            assert.equal(newPackage.VAT, 33)
        })
    })
    describe('testing the ACTIVE property', () => {
        it('should return the instance ACTIVE property', () => {
            assert.equal(newPackage.active, true)
        })
        it('should set a new ACTIVE property for the instance', () => {
            newPackage.active = false
            assert.equal(newPackage.active, false)
        })
    })
    // describe('testing the ACTIVE verification', () => {
    //     it('should throw an error if the active property is not a boolean', () => {
    //         assert.throw(()=>{
    //             newPackage.active = 'it is TRUE'
    //         }, 'Active status must be a boolean');
    //     })
    // })
    describe('testing the toString method', () => {
        it('should print info about the current instance', () => {
            assert.equal(newPackage.toString(), `Package: RD Services (inactive)\n- Value (excl. VAT): 3300\n- Value (VAT 33%): 4389`)
        })
        
    })

})