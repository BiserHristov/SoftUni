let { assert, expect } = require("chai");
let Warehouse = require('./warehouse.js');

describe('Warehouse', () => {
    let warehouse;

    beforeEach(function () {
        warehouse = new Warehouse(12);
    })

    describe('constructor', () => {
        it('Should throw exception error if argument is not a number.', () => {
            assert.throws(() => new Warehouse('Test'), 'Invalid given warehouse space')
            assert.throws(() => new Warehouse({}), 'Invalid given warehouse space')
        })
        it('Should initialize properly.', () => {
            assert.isDefined(warehouse);
            assert.equal(12, warehouse.capacity);
            assert.deepEqual(warehouse.availableProducts, {
                'Food': {},
                'Drink': {}
            })
        })
    })

    describe('addProduct', () => {
        it('Should throw exception error if warehouse is already full.', () => {
            assert.throws(() => warehouse.addProduct('Food', 'Product', 50), 'There is not enough space or the warehouse is already full')
            assert.throws(() => warehouse.addProduct('Drink', 'Product', 50), 'There is not enough space or the warehouse is already full')
        })
        it('Should add product correctly if requirements are met.', () => {
            warehouse.addProduct('Food', 'Product', 10);

            assert.deepEqual({ Product: 10 }, warehouse.availableProducts.Food)
        })
    })

    describe("orderProducts", () => {
        it("Should order all products of given type by quantity descending.", function () {
            warehouse.addProduct('Food', 'C', 3);
            warehouse.addProduct('Drink', 'B', 2);
            warehouse.addProduct('Food', 'A', 1);
            warehouse.addProduct('Drink', 'D', 4);
            warehouse.addProduct('Drink', 'E', 1);

            assert.deepEqual({ C: 3, A: 1 }, warehouse.orderProducts('Food'));
            assert.deepEqual({ D: 4, B: 2, E: 1 }, warehouse.orderProducts('Drink'));
        })
    })

    describe('occupiedCapacity', () => {
        it('Should return the occupied space in the warehouse correctly.', () => {
            warehouse.addProduct('Food', 'C', 3);
            warehouse.addProduct('Drink', 'B', 2);
            warehouse.addProduct('Food', 'A', 1);

            assert.equal(3 + 2 + 1, warehouse.occupiedCapacity());
        })
    })

    describe('revision', () => {
        it('Should return message "The warehouse is empty" if occupiedCapacity is non-positive.', () => {
            assert.equal('The warehouse is empty', warehouse.revision())
        })
        it('Should return correct output when warehouse is not empty.', () => {
            warehouse.addProduct('Food', 'C', 3);
            warehouse.addProduct('Drink', 'B', 2);
            warehouse.addProduct('Food', 'A', 1);

            assert.equal(['Product type - [Food]', '- C 3', '- A 1', 'Product type - [Drink]', '- B 2'].join('\n'), warehouse.revision());
        })
    })

    describe('scrapeAProduct', () => {
        it('Should throw exception error if there is no such product.', () => {
            assert.throws(() => { warehouse.scrapeAProduct('test', 1) }, 'test do not exists')
        })
        it('Should reduce the quantity up to zero of existing product', () => {
            warehouse.addProduct('Food', 'C', 3);
            warehouse.addProduct('Drink', 'B', 2);

            assert.deepEqual({ C: 2 }, warehouse.scrapeAProduct('C', 1));
            assert.deepEqual({ B: 0 }, warehouse.scrapeAProduct('B', 5));
        })
    })
})