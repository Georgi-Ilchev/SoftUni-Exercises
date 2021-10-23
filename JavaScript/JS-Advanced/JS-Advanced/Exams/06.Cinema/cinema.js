const cinema = {
    showMovies: function (movieArr) {

        if (movieArr.length == 0) {
            return 'There are currently no movies to show.';
        } else {
            let result = movieArr.join(', ');
            return result;
        }

    },
    ticketPrice: function (projectionType) {

        const schedule = {
            "Premiere": 12.00,
            "Normal": 7.50,
            "Discount": 5.50
        }
        if (schedule.hasOwnProperty(projectionType)) {
            let price = schedule[projectionType];
            return price;
        } else {
            throw new Error('Invalid projection type.')
        }

    },
    swapSeatsInHall: function (firstPlace, secondPlace) {

        if (!Number.isInteger(firstPlace) || firstPlace <= 0 || firstPlace > 20 ||
            !Number.isInteger(secondPlace) || secondPlace <= 0 || secondPlace > 20 || firstPlace === secondPlace) {
            return "Unsuccessful change of seats in the hall.";
        } else {
            return "Successful change of seats in the hall.";
        }

    }
};

// module.exports = {
//     cinema
// }

const { expect } = require('chai');

describe('cinema tests', () => {
    describe('showMovies tests', () => {
        it('cinema should return message for empty array', () => {
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');
        });

        it('cinema should return movies', () => {
            expect(cinema.showMovies(['King Kong', 'The Tomorrow War', 'Joker']))
                .to.equal('King Kong, The Tomorrow War, Joker');
        });

        it('cinema should return movie for array with single movie', () => {
            expect(cinema.showMovies(['King Kong'])).to.equal('King Kong');
        });
    });

    describe('ticketPrice tests', () => {
        it('Premiere price', () => {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
        });

        it('Normal price', () => {
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
        });

        it('Discount price', () => {
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
        });

        it('Should throw error when type is incorrect', () => {
            expect(() => cinema.ticketPrice('Discountmiss')).to.throw();
        });
    });

    describe('swapSeatsInHall tests', () => {
        it('Should return unsuccesful / only 1 param', () => {
            expect(cinema.swapSeatsInHall(1)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should return unsuccesful / not integers params', () => {
            expect(cinema.swapSeatsInHall(1.2, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1.2, 1.1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 1.2)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should return unsuccesful / one of num is greater than 20', () => {
            expect(cinema.swapSeatsInHall(21, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 21)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(21, 21)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(21.1, 21)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should return unsuccesful / one of num is less or equal to 0 ', () => {
            expect(cinema.swapSeatsInHall(0, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 0)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(0, 0)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(2, -1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-2, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-2, -1)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should return succesful', () => {
            expect(cinema.swapSeatsInHall(1, 2)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 20)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(20, 1)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(6, 14)).to.equal('Successful change of seats in the hall.');
        });
    });
})
