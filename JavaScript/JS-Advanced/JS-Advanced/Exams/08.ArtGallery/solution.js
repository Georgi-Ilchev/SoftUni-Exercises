class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250
        };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        articleModel = articleModel.toLowerCase();
        quantity = Number(quantity);

        if (!this.possibleArticles[articleModel]) {
            throw new Error('This article model is not included in this gallery!');
        }

        let article = this.listOfArticles.find(x => x.articleName == articleName && x.articleModel == articleModel);

        if (article) {
            article.quantity += quantity;
        } else {
            let newArticle = {
                articleModel,
                articleName,
                quantity,
            }

            this.listOfArticles.push(newArticle);
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(x => x.guestName == guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }

        let newGuest = {
            guestName,
            points: personality === 'Vip' ? 500 : personality === 'Middle' ? 250 : 50,
            purchasesArticle: 0
        }

        this.guests.push(newGuest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        articleModel = articleModel.toLowerCase();
        let article = this.listOfArticles.find(x => x.articleName == articleName);

        if (!article || article.articleModel != articleModel) {
            throw new Error(`This article is not found.`);
        }

        if (article.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

        let guest = this.guests.find(x => x.guestName == guestName)
        if (!guest) {
            return `This guest is not invited.`;
        }

        if (guest.points < this.possibleArticles[articleModel]) {
            return `You need to more points to purchase the article.`;
        }

        guest.points -= this.possibleArticles[articleModel];
        article.quantity--;
        guest.purchasesArticle++;

        return `${guestName} successfully purchased the article worth ${this.possibleArticles[articleModel]} points.`;
    }

    showGalleryInfo(criteria) {
        let result = [];
        if (criteria === 'article') {
            result.push(`Articles information:`);

            this.listOfArticles.forEach((el) => {
                result.push(`${el.articleModel} - ${el.articleName} - ${el.quantity}`);
            });
        } else if (criteria === 'guest') {
            result.push('Guests information:');

            this.guests.forEach((el) => {
                result.push(`${el.guestName} - ${el.purchasesArticle}`);
            });
        }

        return result.join('\n');
    }
}

const artGallery = new ArtGallery('Curtis Mayfield');
console.log(artGallery.addArticle('picture', 'Mona Liza', 3));
console.log(artGallery.addArticle('Item', 'Ancient vase', 2));
console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));
