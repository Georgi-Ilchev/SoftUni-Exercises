const { expect } = require("chai");

class HolidayPackage {
    constructor(destination, season) {
        this.vacationers = [];
        this.destination = destination;
        this.season = season;
        this.insuranceIncluded = false; // Default value
    }

    showVacationers() {
        if (this.vacationers.length > 0)
            return "Vacationers:\n" + this.vacationers.join("\n");
        else
            return "No vacationers are added yet";
    }

    addVacationer(vacationerName) {
        if (typeof vacationerName !== "string" || vacationerName === ' ') {
            throw new Error("Vacationer name must be a non-empty string");
        }
        if (vacationerName.split(" ").length !== 2) {
            throw new Error("Name must consist of first name and last name");
        }
        this.vacationers.push(vacationerName);
    }

    get insuranceIncluded() {
        return this._insuranceIncluded;
    }

    set insuranceIncluded(insurance) {
        if (typeof insurance !== 'boolean') {
            throw new Error("Insurance status must be a boolean");
        }
        this._insuranceIncluded = insurance;
    }

    generateHolidayPackage() {
        if (this.vacationers.length < 1) {
            throw new Error("There must be at least 1 vacationer added");
        }
        let totalPrice = this.vacationers.length * 400;

        if (this.season === "Summer" || this.season === "Winter") {
            totalPrice += 200;
        }

        totalPrice += this.insuranceIncluded === true ? 100 : 0;

        return "Holiday Package Generated\n" +
            "Destination: " + this.destination + "\n" +
            this.showVacationers() + "\n" +
            "Price: " + totalPrice;
    }
}

describe("HolidayPackage tests", function () {
    let instance = {};

    beforeEach(() => instance = new HolidayPackage('Italy', 'Summer'));

    describe('constructor', () => {
        it("constructor", function () {
            expect(typeof instance).to.eql('object');
            expect(instance.vacationers).to.eql([]);
            expect(instance.insuranceIncluded).to.eql(false);
            expect(instance.season).to.eql('Summer');
            expect(instance.destination).to.eql('Italy');
        });
    })

    describe('insuranceIncluded', () => {
        it("insuranceIncluded should set property", function () {
            instance.insuranceIncluded = true;
            expect(instance.insuranceIncluded).to.eql(true);
        });

        it("insuranceIncluded should throw error", function () {
            expect(() => instance.insuranceIncluded = '').to.throw(Error, 'Insurance status must be a boolean');
        });
    })

    describe('showVacationers', () => {
        it("Should show all vacationers on new line", function () {
            instance.vacationers = ['gosho', 'pesho'];
            expect(instance.showVacationers()).to.equal('Vacationers:\ngosho\npesho');
        });

        it("Should return message when vacationers is 0", function () {
            expect(instance.showVacationers()).to.equal('No vacationers are added yet');
        });
    })

    describe('addVacationer', () => {
        it("Should throw error when vacationer name is empty space or not string", function () {
            expect(() => instance.addVacationer(' ')).to.throw(Error, 'Vacationer name must be a non-empty string');
            expect(() => instance.addVacationer('gosho')).to.throw(Error, 'Name must consist of first name and last name');
        });

        it("Should add vacationers correctly", function () {
            instance.addVacationer('Gosho Peshev');
            instance.addVacationer('Pesho Goshev');
            expect(instance.vacationers.length).to.equal(2);
        });
    })

    describe('generateHolidayPackage', () => {
        it("Should throw error when there is no vacationers", function () {
            expect(() => instance.generateHolidayPackage()).to.throw(Error, 'There must be at least 1 vacationer added');
        });

        it("Should generate holiday package with season", function () {
            instance.vacationers = ['Gosho Ivanov'];
            expect(instance.generateHolidayPackage()).to.equal('Holiday Package Generated\n' +
                'Destination: ' + 'Italy' + '\n' +
                'Vacationers:\n' + 'Gosho Ivanov' + '\n' +
                'Price: 600');
        });

        it("Should generate holiday package without season", function () {
            instance.vacationers = ['Gosho Ivanov'];
            instance.season = '';
            expect(instance.generateHolidayPackage()).to.equal('Holiday Package Generated\n' +
                'Destination: ' + 'Italy' + '\n' +
                'Vacationers:\n' + 'Gosho Ivanov' + '\n' +
                'Price: 400');
        });

        it("Should generate holiday package with season and insuranceIncluded - true", function () {
            instance.vacationers = ['Gosho Ivanov'];
            instance.insuranceIncluded = true;
            expect(instance.generateHolidayPackage()).to.equal('Holiday Package Generated\n' +
                'Destination: ' + 'Italy' + '\n' +
                'Vacationers:\n' + 'Gosho Ivanov' + '\n' +
                'Price: 700');
        });

        it("Should generate holiday package with more vacationers", function () {
            instance.vacationers = ['Gosho Ivanov', 'Petyr Ivanov'];
            expect(instance.generateHolidayPackage()).to.equal('Holiday Package Generated\n' +
                'Destination: ' + 'Italy' + '\n' +
                'Vacationers:\n' + 'Gosho Ivanov\nPetyr Ivanov' + '\n' +
                'Price: 1000');
        });
    })
});
