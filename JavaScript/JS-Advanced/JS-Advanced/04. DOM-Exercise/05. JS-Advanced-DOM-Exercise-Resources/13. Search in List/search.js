function search() {
   const towns = Array.from(document.querySelectorAll('ul li'));
   const search = document.getElementById('searchText').value;
   let count = 0;

   towns.forEach((el) => {
      if (el.innerHTML.includes(search)) {
         el.style.fontWeight = 'bold';
         el.style.textDecoration = 'underline';
         count++;
      } else {
         el.style.fontWeight = 'normal';
         el.style.textDecoration = '';
      }
   })

   document.getElementById('result').textContent = `${count} matches found`;
}
