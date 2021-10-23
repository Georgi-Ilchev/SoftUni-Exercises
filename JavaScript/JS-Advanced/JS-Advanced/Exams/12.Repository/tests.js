const { expect } = require("chai");
let { Repository } = require("./solution.js");

describe("Repository", function () {
    describe("constructor", function () {
        it("Should set initialize with valid data", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);

            //deep eql
            expect(rep.props).to.eql(props);
            expect(rep.data.size).to.equal(0);
            expect(rep.nextId()).to.equal(0);
        });
    });

    describe("count", function () {
        it("Should reflect correct count", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 23 };

            expect(rep.count).to.equal(0);
            rep.add(obj1);
            expect(rep.count).to.equal(1);
            rep.update(0, obj1);
            expect(rep.count).to.equal(1);
            rep.del(0);
            expect(rep.count).to.equal(0);
        });
    });

    describe("add", function () {
        it("Should add entity correctly", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 23 };
            let obj2 = { name: 'gosho2', age: 22 };

            let id = rep.add(obj1);
            expect(id).to.equal(0);
            let id2 = rep.add(obj2);
            expect(id2).to.equal(1);

            let actual = rep.data.get(id2);
            expect(actual).to.eql(obj2);
        });

        it("Should throw error when props are not matched", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho' };
            let obj2 = { name: 'gosho2', age: true };
            let obj3 = { name: 'gosho3', age: 22, hobby: true };

            expect(() => rep.add(obj1)).to.throw(Error, `Property age is missing from the entity!`);
            expect(() => rep.add(obj2)).to.throw(TypeError, `Property age is not of correct type!`);
            expect(() => rep.add(obj3)).to.throw(TypeError, `Property hobby is not of correct type!`);
        });
    });

    describe("getId", function () {
        it("Should reflect getId entity correctly", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 23 };
            let obj2 = { name: 'gosho2', age: 22 };

            rep.add(obj1);
            rep.add(obj2);

            let actual = rep.getId(1);
            expect(actual).to.eql(obj2);
        });

        it("Should throw error when id does not exist", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 22 };

            expect(() => rep.getId(0)).to.throw(Error, `Entity with id: 0 does not exist!`);
            rep.add(obj1);
            expect(() => rep.getId(1)).to.throw(Error, `Entity with id: 1 does not exist!`);
        });
    });

    describe("update", function () {
        it("Should add entity correctly", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 20 };
            let obj2 = { name: 'gosho2', age: 22 };
            let obj3 = { name: 'gosho3', age: 23 };
            let obj4 = { name: 'gosho4', age: 24 };

            rep.add(obj1);
            rep.add(obj2);

            rep.update(1, obj3);
            expect(rep.data.get(1)).to.eql(obj3);

            rep.update(0, obj4);
            expect(rep.data.get(0)).to.eql(obj4);
        });

        it("Should throw error when parameters are incorrect", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 22 };
            let obj2 = { name: 'gosho' };
            let obj3 = { name: 'gosho', age: true };
            let obj4 = { name: 'gosho', age: 22, hobby: true };

            expect(() => rep.update(0, obj1)).to.throw(Error, `Entity with id: 0 does not exist!`);
            rep.add(obj1);
            expect(() => rep.update(1, obj1)).to.throw(Error, `Entity with id: 1 does not exist!`);

            expect(() => rep.update(0, obj2)).to.throw(Error, `Property age is missing from the entity!`);
            expect(() => rep.update(0, obj3)).to.throw(TypeError, `Property age is not of correct type!`);
            expect(() => rep.update(0, obj4)).to.throw(TypeError, `Property hobby is not of correct type!`);
        });
    });

    describe("del", function () {
        it("Should reflect delete correctly", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 20 };
            let obj2 = { name: 'gosho2', age: 22 };
            rep.add(obj1);
            rep.add(obj2);

            rep.del(0);
            expect(rep.data.get(1)).to.eql(obj2);
            rep.del(1);
            expect(rep.data.size).to.equal(0);
        });

        it("Should throw error when parameters are incorrect", function () {
            let props = { name: 'string', age: 'number' };
            let rep = new Repository(props);
            let obj1 = { name: 'gosho', age: 22 };

            expect(() => rep.del(0)).to.throw(Error, `Entity with id: 0 does not exist!`);
            rep.add(obj1);
            expect(() => rep.del(1)).to.throw(Error, `Entity with id: 1 does not exist!`);
        });
    });
});
