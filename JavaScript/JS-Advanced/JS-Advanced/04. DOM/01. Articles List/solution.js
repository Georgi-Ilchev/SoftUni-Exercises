//50 points
function createArticle() {
	let titleInputElement = document.getElementById('createTitle');
	let contentInputElement = document.getElementById('createContent');

	let headingElement = document.createElement('h3');
	headingElement.innerHTML = titleInputElement.value;
	titleInputElement.value = '';

	let contentElement = document.createElement('p');
	contentElement.innerHTML = contentInputElement.value;
	contentInputElement.value = '';

	let articleElement = document.createElement('article');
	articleElement.appendChild(headingElement);
	articleElement.appendChild(contentElement);

	let articleSectionElement = document.getElementById('articles');
	articleSectionElement.appendChild(articleElement);
}


//100 points
function createArticle() {
	let input = document.getElementById('createTitle')
	let textArea = document.getElementById('createContent')
	let articles = document.getElementById('articles')

	let article = document.createElement('article')
	let h3 = document.createElement('h3')
	let p = document.createElement('p')

	if (input.value !== '' && textArea.value !== '') {
		h3.innerHTML = input.value;
		p.innerHTML = textArea.value;
		article.appendChild(h3);
		article.appendChild(p);
		articles.appendChild(article);
	}
	input.value = '';
	textArea.value = '';
}