function getArticleGenerator(articles) {
    const array = articles;
    const resultDiv = document.getElementById('content');

    return () => {
        if (array.length != 0) {
            const article = document.createElement('article');
            article.textContent = array.shift();

            resultDiv.appendChild(article);
        }
    }
}
