function printDeckOfCards(cards) {
    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        };

        if (faces.includes(face) == false) {
            throw new Error('Invalid face');
        }

        if (Object.keys(suits).includes(suit) == false) {
            throw new Error('Invalid suit');
        }

        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        };
    }

    //1
    // let result = [];

    // for (const card of cards) {
    //     const face = card.slice(0, -1);
    //     const suit = card.slice(-1);
    //     try {
    //         result.push(createCard(face, suit));
    //     } catch (error) {
    //         console.log('Invalid card: ' + card);
    //     }
    // }

    // console.log(result.join(' '));

    //2
    try {
        console.log(cards.map(card => {
            const face = card.slice(0, -1);
            const suit = card.slice(-1);
            try {
                return createCard(face, suit);
            } catch (error) {
                throw new Error('Invalid card: ' + card);
            }
        }).join(' '));
    } catch (error) {
        console.log(error.message);
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);