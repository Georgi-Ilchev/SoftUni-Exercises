function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let input = document.getElementById('searchField');
      let search = input.value.toLowerCase();
      let tableElements = Array.from(document.querySelectorAll('tbody tr'));

      tableElements.forEach((el) => {
         let text = el.textContent.toLowerCase();

         if (text.includes(search)) {
            el.classList.add('select');
         } else {
            el.classList.remove('select')
         }
      })

      input.value = '';
   }
}