function getArticleGenerator(articles) {
    let content = document.getElementById('content');

    function showNext() {
        if (articles.length > 0) {
            let div = document.createElement('article');
            div.textContent = articles.shift();

            content.appendChild(div);
        }
    }
    return showNext;
}
