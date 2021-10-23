function solveClasses() {
    class Hall {
        constructor(capacity, name) {
            this.capacity = Number(capacity);
            this.name = name;
            this.events = [];
            this.allPerformers = [];
        }

        hallEvent(title) {
            if (this.events.includes(title)) {
                throw new Error(`This event is already added!`);
            }

            this.events.push(title);

            return `Event is added.`;
        }

        close() {
            this.events = [];

            return `${this.name} hall is closed.`;
        }

        toString() {
            let result = '';

            result += `${this.name} hall - ${this.capacity}`;

            if (this.events.length > 0) {
                result += `\nEvents: ${this.events.join(', ').trim()}`;
            }

            return result;
        }
    }

    class MovieTheater extends Hall {
        constructor(capacity, name, screenSize) {
            super(capacity, name);
            this.screenSize = screenSize;
            this.events = [];
        }

        close() {
            return super.close() + "Аll screenings are over.";
        }

        toString() {
            return `${super.toString()}\n${this.name} is a movie theater with ${this.screenSize} screensize and ${this.capacity} seats capacity.`;
        }
    }

    class ConcertHall extends Hall {
        constructor(capacity, name) {
            super(capacity, name);
            this.events = [];
        }

        hallEvent(title, performers) {
            if (this.events.includes(title)) {
                throw new Error("This event is already added!");
            } else {
                super.hallEvent(title);

                this.allPerformers.push(performers);

                return "Event is added.";
            }
        }

        close() {
            return super.close() + "Аll performances are over.";
        }

        toString() {
            return `${super.toString()}${this.events.length > 0 ? `\nPerformers: ${this.allPerformers.join(', ')}.` : ''}`;
        }
    }

    return {
        Hall,
        MovieTheater,
        ConcertHall
    }
}

let concert = new classes.ConcertHall(5000, 'Diamond');
console.log(concert.hallEvent('The Chromatica Ball', ['LADY GAGA']));
console.log(concert.toString());
console.log(concert.close());
console.log(concert.toString());
