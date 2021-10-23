class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500
        }
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (Number(money) < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0,
        };

        this.listOfParticipants.push(participant);

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        if (!this.listOfParticipants.some(x => x.name === name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        let participant = this.listOfParticipants.find(p => p.name === name);
        let index = this.listOfParticipants.indexOf(participant);
        this.listOfParticipants.splice(index, 1);

        this.listOfParticipants.slic
        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        if (participant2 === undefined && typeOfGame == 'Battleship') {
            if (!this.listOfParticipants.some(p => p.name == participant1)) {
                throw new Error(`Invalid entered name/s.`);
            }

            this.listOfParticipants.find(p => p.name == participant1).power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        } else if (participant1 !== undefined && participant2 !== undefined) {
            if (!this.listOfParticipants.some(p => p.name == participant1) ||
                !this.listOfParticipants.some(p => p.name == participant2)) {
                throw new Error(`Invalid entered name/s.`);
            }

            let firstParticipant = this.listOfParticipants.find(p => p.name === participant1);
            let secondParticipant = this.listOfParticipants.find(p => p.name === participant2);

            if (firstParticipant.condition !== secondParticipant.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (firstParticipant.power > secondParticipant.power) {
                firstParticipant.wins += 1;
                return `The ${participant1} is winner in the game ${typeOfGame}.`;
            } else if (firstParticipant.power < secondParticipant.power) {
                secondParticipant.wins += 1;
                return `The ${participant2} is winner in the game ${typeOfGame}.`;

            }

            return `There is no winner.`;
        }
    }

    toString() {
        let result = '';
        result += `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        this.listOfParticipants.forEach((p) => result += `${p.name} - ${p.condition} - ${p.power} - ${p.wins}\n`);

        return result.trim();
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

