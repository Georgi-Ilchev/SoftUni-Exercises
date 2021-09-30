function create(words) {
   const content = document.getElementById('content');

   for (const word of words) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');

      paragraph.textContent = word;
      paragraph.style.display = 'none';

      div.appendChild(paragraph);
      div.addEventListener('click', reveal);

      content.appendChild(div);
   }

   function reveal(ev) {
      ev.currentTarget.children[0].style.display = '';
   }
}


function create(words) {
   const content = document.getElementById('content');
   content.addEventListener('click', reveal);


   for (const word of words) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');

      paragraph.textContent = word;
      paragraph.style.display = 'none';

      div.appendChild(paragraph);

      content.appendChild(div);
   }

   function reveal(ev) {
      if (ev.target.tagName == 'DIV' && ev.target != content) {
         ev.target.children[0].style.display = '';
      }
   }
}