// not tested in judge
class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
        this._loggedUsers = [];
    }

    register(username, password, repeatPassword, email) {
        if (username === '' || password === '' || repeatPassword === '' || email === '') {
            throw new Error(`Input can not be empty`);
        }

        if (password !== repeatPassword) {
            throw new Error(`Passwords do not match`);
        }

        let user = this.findUser(username, email);

        if (!user) {
            this._users.push({
                username,
                password,
                email
            });

            return `${username} with ${email} was registered successfully!`;
        } else {
            throw new Error(`This user already exists`);
        }
    }

    login(username, password) {
        let user = this.findUser(username);

        if (!user) {
            throw new Error('There is no such user');
        }

        if (user.password === password) {
            this._loggedUsers.push(user);
            return `Hello! You have logged in successfully`;
        }
    }

    logout(username, password) {
        let user = this.findUser(username);

        if (!user) {
            throw new Error('There is no such user');
        }

        if (user.password === password) {
            let index = this._users.indexOf(user);
            this._loggedUsers.splice(index, 1);

            return `You have logged out successfully`;
        }
    }

    postQuestion(username, question) {
        let user = this.findUser(username);
        let loggedIn = this.findLoggedInUser(user);

        if (!user || !loggedIn) {
            throw new Error(`You should be logged in to post questions`);
        }

        if (question === '') {
            throw new Error(`Invalid question`);
        }

        let currentQuestion = {
            id: this._id,
            question,
            username,
            answers: [],
        }

        this._id++;
        this._questions.push(currentQuestion);

        return `Your question has been posted successfully`;
    }

    postAnswer(username, questionId, answer) {
        let user = this.findUser(username);
        let loggedIn = this.findLoggedInUser(user);

        if (!user || !loggedIn) {
            throw new Error('You should be logged in to post answers');
        }

        if (answer === '') {
            throw new Error('Invalid answer');
        }

        let question = this._questions.find(q => q.id == questionId);
        if (!question) {
            throw new Error('There is no such question');
        }

        let resultAnswer = {
            username,
            answer,
        };

        question['answers'].push(resultAnswer);

        return 'Your answer has been posted successfully';
    }

    showQuestions() {
        let result = '';

        this._questions.forEach((x) => {
            result += `Question ${x.id} by ${x.username}: ${x.question}\n`;

            for (const line in x.answers) {
                let currentAnswer = x.answers[line];

                result += `---${currentAnswer.username}: ${currentAnswer.answer}\n`;
            }
        });

        result = result.trim();

        return result;
    }

    findUser(username, email) {
        if (email === undefined) {
            return this._users.find(u => u.username === username)
        } else {
            return this._users.find(u => u.username === username || u.email === email);
        }
    }

    findLoggedInUser(user) {
        return this._loggedUsers.includes(user);
    }
}

// let forum = new Forum();

// forum.register('Michael', '123', '123', 'michael@abv.bg');
// forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
// forum.login('Michael', '123');
// forum.login('Stoyan', '123ab7');

// forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
// forum.postAnswer('Stoyan', 1, "Yes, I have rented one last year.");
// forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
// forum.postAnswer('Michael', 2, "How old is she?");
// forum.postAnswer('Michael', 2, "Tell us how tall she is.");

// console.log(forum.showQuestions());


let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter', 1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny', 1, "What was your budget");
forum.postAnswer('Peter', 1, "$50");
forum.postAnswer('Jonny', 1, "Thank you :)");

console.log(forum.showQuestions());

