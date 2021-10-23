const { expect } = require("chai");

let pizzUni = {
    makeAnOrder: function (obj) {

        if (!obj.orderedPizza) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        } else {
            let result = `You just ordered ${obj.orderedPizza}`
            if (obj.orderedDrink) {
                result += ` and ${obj.orderedDrink}.`
            }
            return result;
        }
    },

    getRemainingWork: function (statusArr) {

        const remainingArr = statusArr.filter(s => s.status != 'ready');

        if (remainingArr.length > 0) {

            let pizzaNames = remainingArr.map(p => p.pizzaName).join(', ')
            let pizzasLeft = `The following pizzas are still preparing: ${pizzaNames}.`

            return pizzasLeft;
        } else {
            return 'All orders are complete!'
        }

    },

    orderType: function (totalSum, typeOfOrder) {
        if (typeOfOrder === 'Carry Out') {
            totalSum -= totalSum * 0.1;

            return totalSum;
        } else if (typeOfOrder === 'Delivery') {

            return totalSum;
        }
    }
}

describe("Pizza place tests", function () {
    describe("makeAnOrder", function () {
        it("Should return confirmation message when pizza is ordered", function () {
            let order = {
                orderedPizza: 'Margaritta'
            }
            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza}`);
        });

        it("Should return confirmation message when pizza and drink is ordered", function () {
            let order = {
                orderedPizza: 'Margaritta',
                orderedDrink: 'Cola'
            }
            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza} and ${order.orderedDrink}.`);
        });

        it("Should throw when there is no ordered pizza", function () {
            let order = {
                orderedDrink: 'Cola'
            };
            let order1 = {};

            expect(() => pizzUni.makeAnOrder(order)).to.throw(`You must order at least 1 Pizza to finish the order.`);
            expect(() => pizzUni.makeAnOrder(order1)).to.throw(`You must order at least 1 Pizza to finish the order.`);
            expect(() => pizzUni.makeAnOrder()).to.throw();
        });
    });

    describe("getRemainingWork", function () {
        it("Should return all orders completed when one ready status is given", function () {
            let statusArr = [{ pizzaName: 'Margaritta', status: 'ready' }];
            let statusArr1 = [{ pizzaName: 'Margaritta', status: 'ready' }, { pizzaName: 'Pizza', status: 'ready' }];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal('All orders are complete!');
            expect(pizzUni.getRemainingWork(statusArr1)).to.equal('All orders are complete!');
        });

        it("Should return remaining pizzas when there is one or more pending order", function () {
            let statusArr = [{ pizzaName: 'Margaritta', status: 'preparing' }];
            let statusArr1 = [{ pizzaName: 'Margaritta', status: 'preparing' }, { pizzaName: 'Pizza', status: 'ready' }];
            let statusArr2 = [{ pizzaName: 'Margaritta', status: 'preparing' }, { pizzaName: 'Pizza', status: 'preparing' }];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta.`);
            expect(pizzUni.getRemainingWork(statusArr1)).to.equal(`The following pizzas are still preparing: Margaritta.`);
            expect(pizzUni.getRemainingWork(statusArr2)).to.equal(`The following pizzas are still preparing: Margaritta, Pizza.`);
        });
    });

    describe("orderType", function () {
        it("Should return sum of order/Delivery", function () {
            expect(pizzUni.orderType(20, 'Delivery')).to.equal(20);
        });

        it("Should return sum of order with discount/Carry out", function () {
            expect(pizzUni.orderType(20, 'Carry Out')).to.equal(18);
        });
    });

});
