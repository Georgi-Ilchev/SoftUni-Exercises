const { expect } = require("chai");

class ChristmasMovies {
    constructor() {
        this.movieCollection = [];
        this.watched = {};
        this.actors = [];
    }

    buyMovie(movieName, actors) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        let uniqueActors = new Set(actors);

        if (movie === undefined) {
            this.movieCollection.push({ name: movieName, actors: [...uniqueActors] });
            let output = [];
            [...uniqueActors].map(actor => output.push(actor));
            return `You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!`;
        } else {
            throw new Error(`You already own ${movieName} in your collection!`);
        }
    }

    discardMovie(movieName) {
        let filtered = this.movieCollection.filter(x => x.name === movieName)

        if (filtered.length === 0) {
            throw new Error(`${movieName} is not at your collection!`);
        }
        let index = this.movieCollection.findIndex(m => m.name === movieName);
        this.movieCollection.splice(index, 1);
        let { name, _ } = filtered[0];
        if (this.watched.hasOwnProperty(name)) {
            delete this.watched[name];
            return `You just threw away ${name}!`;
        } else {
            throw new Error(`${movieName} is not watched!`);
        }

    }

    watchMovie(movieName) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        if (movie) {
            if (!this.watched.hasOwnProperty(movie.name)) {
                this.watched[movie.name] = 1;
            } else {
                this.watched[movie.name]++;
            }
        } else {
            throw new Error('No such movie in your collection!');
        }
    }

    favouriteMovie() {
        let favourite = Object.entries(this.watched).sort((a, b) => b[1] - a[1]);
        if (favourite.length > 0) {
            return `Your favourite movie is ${favourite[0][0]} and you have watched it ${favourite[0][1]} times!`;
        } else {
            throw new Error('You have not watched a movie yet this year!');
        }
    }

    mostStarredActor() {
        let mostStarred = {};
        if (this.movieCollection.length > 0) {
            this.movieCollection.forEach(el => {
                let { _, actors } = el;
                actors.forEach(actor => {
                    if (mostStarred.hasOwnProperty(actor)) {
                        mostStarred[actor]++;
                    } else {
                        mostStarred[actor] = 1;
                    }
                })
            });
            let theActor = Object.entries(mostStarred).sort((a, b) => b[1] - a[1]);
            return `The most starred actor is ${theActor[0][0]} and starred in ${theActor[0][1]} movies!`;
        } else {
            throw new Error('You have not watched a movie yet this year!')
        }
    }
}

describe("ChristmasMovies tests", function () {
    let instance;
    this.beforeEach(() => {
        instance = new ChristmasMovies();
    });

    describe("Testis all initial properties", function () {
        it("Instants with no parameters", function () {
            expect(instance.movieCollection).to.eql([]);
            expect(instance.actors).to.eql([]);
            expect(instance.watched).to.eql({});
            expect(instance.movieCollection.length).to.eql(0);
            expect(instance.actors.length).to.eql(0);
        });
    });

    describe("buyMovie", function () {
        it("Should add movie", function () {
            expect(instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']))
                .to.equal(`You just got Last Christmas to your collection in which Madison Ingoldsby, Emma Thompson, Boris Isakovic are taking part!`);
        });

        it("Should throw error when movie exist", function () {
            instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']);
            expect(() => instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']))
                .to.throw(Error, `You already own Last Christmas in your collection!`);
        });
    });

    describe("discardMovie", function () {
        it("Should throw error when filtered movie is not founded", function () {
            expect(() => instance.discardMovie('Last Christmas')).to.throw(Error, `Last Christmas is not at your collection!`)
        });

        it("Should throw error when the input movie is not watched", function () {
            instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']);
            expect(() => instance.discardMovie('Last Christmas')).to.throw(Error, `Last Christmas is not watched!`);
        });

        it("Should return a message when movie is removed", function () {
            instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']);
            instance.watchMovie('Last Christmas');
            expect(instance.discardMovie('Last Christmas')).to.equal('You just threw away Last Christmas!');
        });
    });

    describe("watchMovie", function () {
        it("Should throw error when the input movie is not found", function () {
            expect(() => instance.watchMovie('Last Christmas')).to.throw(Error, 'No such movie in your collection!');
        });

        it("Should return the movie watchers", function () {
            instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']);
            instance.watchMovie('Last Christmas');
            instance.watchMovie('Last Christmas');
            instance.watchMovie('Last Christmas');

            expect(instance.watched['Last Christmas']).to.eql(3);
        });
    });

    describe("favouriteMovie", function () {
        it("Should throw error when watchers collection is zero", function () {
            expect(() => instance.favouriteMovie()).to.throw(Error, 'You have not watched a movie yet this year!');
        });

        it("Should return the movie with the most views", function () {
            instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']);
            instance.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

            instance.watchMovie('Home Alone');
            instance.watchMovie('Last Christmas');
            instance.watchMovie('Home Alone');
            instance.watchMovie('Home Alone');

            expect(instance.favouriteMovie()).to.equal(`Your favourite movie is Home Alone and you have watched it 3 times!`)
        });
    });

    describe("mostStarredActor", function () {
        it("Shold throw error when movie collection is empty", function () {
            expect(() => instance.mostStarredActor()).to.throw(Error, 'You have not watched a movie yet this year!');
        });

        it("Shold return the most starred actor", function () {
            instance.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']);
            instance.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            instance.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Daniel Stern']);
            instance.buyMovie('Home Alone 3', ['Macaulay Culkin', 'Joe Pesci']);

            expect(instance.mostStarredActor()).to.equal('The most starred actor is Macaulay Culkin and starred in 3 movies!')
        });
    });
});
