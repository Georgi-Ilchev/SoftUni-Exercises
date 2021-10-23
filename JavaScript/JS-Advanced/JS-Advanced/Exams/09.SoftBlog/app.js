function solve() {
   let createBtn = document.querySelector('.site-content aside button.btn.create');
   createBtn.addEventListener('click', createArticleHandler);

   function createArticleHandler(ev) {
      ev.preventDefault();

      let authorInput = document.querySelector('#creator');
      let titleInput = document.querySelector('#title');
      let categoryInput = document.querySelector('#category');
      let contentTextArea = document.querySelector('#content');

      let articleElement = document.createElement('article');

      let titleHeading = document.createElement('h1');
      titleHeading.textContent = titleInput.value;

      let categoryParagraph = document.createElement('p');
      categoryParagraph.textContent = 'Category:';
      let categoryStrong = document.createElement('strong');
      categoryStrong.textContent = categoryInput.value;
      categoryParagraph.appendChild(categoryStrong);

      let creatorParagraph = document.createElement('p');
      creatorParagraph.textContent = 'Creator:';
      let creatorStrong = document.createElement('strong');
      creatorStrong.textContent = authorInput.value;
      creatorParagraph.appendChild(creatorStrong);

      let contentParagraph = document.createElement('p');
      contentParagraph.textContent = contentTextArea.value;

      let buttonsDiv = document.createElement('div');
      buttonsDiv.classList.add('buttons');

      let deleteBtn = document.createElement('button');
      deleteBtn.textContent = 'Delete';
      deleteBtn.classList.add('btn', 'delete');
      deleteBtn.addEventListener('click', deleteArticleHandler);

      let archiveBtn = document.createElement('button');
      archiveBtn.textContent = 'Archive';
      archiveBtn.classList.add('btn', 'archive');
      archiveBtn.addEventListener('click', archiveArticleHandler);

      buttonsDiv.appendChild(deleteBtn);
      buttonsDiv.appendChild(archiveBtn);

      articleElement.appendChild(titleHeading);
      articleElement.appendChild(categoryParagraph);
      articleElement.appendChild(creatorParagraph);
      articleElement.appendChild(contentParagraph);
      articleElement.appendChild(buttonsDiv);

      let postsSection = document.querySelector('.site-content main section');
      postsSection.appendChild(articleElement);
   }

   function deleteArticleHandler(ev) {
      let deleteButton = ev.target;
      let articleToDelete = deleteButton.parentElement.parentElement;

      articleToDelete.remove();
   }

   function archiveArticleHandler(ev) {
      let articleToArchive = ev.target.parentElement.parentElement;
      let archiveOl = document.querySelector('.archive-section ol');

      let archiveLis = Array.from(archiveOl.querySelectorAll('li'));
      let articleTitleHeading = articleToArchive.querySelector('h1');
      let articleTitle = articleTitleHeading.textContent;

      let newTitleLi = document.createElement('li');
      newTitleLi.textContent = articleTitle;

      articleToArchive.remove();

      archiveLis.push(newTitleLi);
      archiveLis
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => archiveOl.appendChild(li));
   }
}


