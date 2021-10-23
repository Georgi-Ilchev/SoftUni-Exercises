class Vacationer {
    constructor(fullName, cardInfo = [1111, '', 111]) {
        this.fullName = fullName;
        this.addCreditCardInfo(cardInfo);
        this.idNumber = this.generateIDNumber();
        this.creditCard;
        this.wishList = [];
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(value) {
        if (value.length !== 3) {
            throw new Error("Name must include first name, middle name and last name");
        }

        if (value.some(x => ! /^[A-Z][a-z]+$/g.test(x))) {
            throw new Error('Invalid full name');
        }

        this._fullName = { firstName: value[0], middleName: value[1], lastName: value[2] };
    }

    addCreditCardInfo(input) {
        if (input.length < 3) {
            throw new Error(`Missing credit card information`);
        }

        if (typeof input[0] !== 'number' || typeof input[2] !== 'number') {
            throw new Error(`Invalid credit card details`);
        }

        const cardNumber = input[0];
        const expirationDate = input[1];
        const securityNumber = input[2];

        this.creditCard = {
            cardNumber,
            expirationDate,
            securityNumber
        }
    }

    generateIDNumber() {
        const additional = ['a', 'e', 'o', 'i', 'u'].includes(this.fullName.lastName.charAt(this.fullName.lastName.length - 1)) ? 8 : 7;

        return `${((231 * this.fullName.firstName.charCodeAt(0)) + (139 * this.fullName.middleName.length))}${additional}`;
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error(`Destination already exists in wishlist`);
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {
        return `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}
ID Number: ${this.idNumber}
Wishlist:
${this.wishList.length > 0 ? this.wishList.join(', ') : 'empty'}
Credit Card:
Card Number: ${this.creditCard.cardNumber}
Expiration Date: ${this.creditCard.expirationDate}
Security Number: ${this.creditCard.securityNumber}`;
    }
}



// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"],
    [123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());
