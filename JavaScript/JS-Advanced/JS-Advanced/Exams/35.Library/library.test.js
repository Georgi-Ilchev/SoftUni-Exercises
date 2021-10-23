const { expect } = require("chai");

const library = {
    calcPriceOfBook(nameOfBook, year) {

        let price = 20;
        if (typeof nameOfBook != "string" || !Number.isInteger(year)) {
            throw new Error("Invalid input");
        } else if (year <= 1980) {
            let total = price - (price * 0.5);
            return `Price of ${nameOfBook} is ${total.toFixed(2)}`;
        }
        return `Price of ${nameOfBook} is ${price.toFixed(2)}`;
    },

    findBook: function (booksArr, desiredBook) {
        if (booksArr.length == 0) {
            throw new Error("No books currently available");
        } else if (booksArr.find(e => e == desiredBook)) {
            return "We found the book you want.";
        } else {
            return "The book you are looking for is not here!";
        }

    },
    arrangeTheBooks(countBooks) {
        const countShelves = 5;
        const availableSpace = countShelves * 8;

        if (!Number.isInteger(countBooks) || countBooks < 0) {
            throw new Error("Invalid input");
        } else if (availableSpace >= countBooks) {
            return "Great job, the books are arranged.";
        } else {
            return "Insufficient space, more shelves need to be purchased.";
        }
    }

};

describe("Library tests", function () {
    describe("calcPriceOfBook", function () {
        it("Should throw error when book name isn't string", function () {
            expect(() => library.calcPriceOfBook(1, 2021)).to.throw(Error, 'Invalid input');
        });

        it("Should throw error when book year isn't number", function () {
            expect(() => library.calcPriceOfBook('Coding', 'a')).to.throw(Error, 'Invalid input');
        });

        it("Should expect discount if book year is <= 1980", function () {
            expect(library.calcPriceOfBook('Coding', 1980)).to.equal(`Price of Coding is 10.00`);
            expect(library.calcPriceOfBook('Coding', 1979)).to.equal(`Price of Coding is 10.00`);
        });

        it("Should expect discount if book year is > 1980", function () {
            expect(library.calcPriceOfBook('Coding', 1981)).to.equal(`Price of Coding is 20.00`);
            expect(library.calcPriceOfBook('Coding', 2010)).to.equal(`Price of Coding is 20.00`);
        });

    });

    describe("findBook", function () {
        it("Should throw error when cannot find book in array", function () {
            expect(() => library.findBook([], 'Coding')).to.throw(Error, 'No books currently available');
        });

        it("Should return the current book", function () {
            expect(library.findBook(['Coding', 'Book'], 'Coding')).to.equal('We found the book you want.');
        });

        it("Should return the not founded book", function () {
            expect(library.findBook(['Coding', 'Book'], 'Clean Code')).to.equal('The book you are looking for is not here!');
        });
    });

    describe("arrangeTheBooks", function () {
        it("Should throw error when input is invalid", function () {
            expect(() => library.arrangeTheBooks(1.1)).to.throw(Error, 'Invalid input');
            expect(() => library.arrangeTheBooks(-1)).to.throw(Error, 'Invalid input');
        });

        it("Should return message for more available spaces", function () {
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(39)).to.equal('Great job, the books are arranged.');
        });

        it("Should return message for not available spaces", function () {
            expect(library.arrangeTheBooks(41)).to.equal('Insufficient space, more shelves need to be purchased.');
        });
    });
});
