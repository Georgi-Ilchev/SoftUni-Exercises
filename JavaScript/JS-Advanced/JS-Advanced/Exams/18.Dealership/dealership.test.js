const { expect } = require("chai");

let dealership = {
    newCarCost: function (oldCarModel, newCarPrice) {

        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        if (discountForOldCar.hasOwnProperty(oldCarModel)) {
            let discount = discountForOldCar[oldCarModel];
            let finalPrice = newCarPrice - discount;
            return finalPrice;
        } else {
            return newCarPrice;
        }
    },

    carEquipment: function (extrasArr, indexArr) {
        let selectedExtras = [];
        indexArr.forEach(i => {
            selectedExtras.push(extrasArr[i])
        });

        return selectedExtras;
    },

    euroCategory: function (category) {
        if (category >= 4) {
            let price = this.newCarCost('Audi A4 B8', 30000);
            let total = price - (price * 0.05)
            return `We have added 5% discount to the final price: ${total}.`;
        } else {
            return 'Your euro category is low, so there is no discount from the final price!';
        }
    }
}

describe("Dealership", function () {
    describe("newCarCost", function () {
        it("Should return original price when model unsuported", function () {
            expect(dealership.newCarCost('a', 1)).to.equal(1);
        });

        it("Should return discounted price when model suported", function () {
            expect(dealership.newCarCost('Audi A4 B8', 30000)).to.equal(15000);
            expect(dealership.newCarCost('Audi A6 4K', 40000)).to.equal(20000);
            expect(dealership.newCarCost('Audi A8 D5', 50000)).to.equal(25000);
            expect(dealership.newCarCost('Audi TT 8J', 36000)).to.equal(22000);
        });
    });

    describe("carEquipment", function () {
        it('single element, single pick', () => {
            expect(dealership.carEquipment(['a'], [0])).to.eql(['a']);
        });

        it('more elements, more picks', () => {
            expect(dealership.carEquipment(['a', 'b', 'c'], [0, 2])).to.eql(['a', 'c']);
            expect(dealership.carEquipment(['a', 'b', 'c'], [1])).to.eql(['b']);
            expect(dealership.carEquipment(['a', 'b', 'c'], [2, 1])).to.eql(['c', 'b']);
        });
    });

    describe("euroCategory", function () {
        it('euro category is bellow 4', () => {
            expect(dealership.euroCategory(3)).to.equal('Your euro category is low, so there is no discount from the final price!');
            expect(dealership.euroCategory(2)).to.equal('Your euro category is low, so there is no discount from the final price!');
            expect(dealership.euroCategory(1)).to.equal('Your euro category is low, so there is no discount from the final price!');
            expect(dealership.euroCategory(0)).to.equal('Your euro category is low, so there is no discount from the final price!');
            expect(dealership.euroCategory(-1)).to.equal('Your euro category is low, so there is no discount from the final price!');
        });

        it('euro category is above 4', () => {
            expect(dealership.euroCategory(4)).to.equal(`We have added 5% discount to the final price: 14250.`);
            expect(dealership.euroCategory(5)).to.equal(`We have added 5% discount to the final price: 14250.`);
        });
    });
});