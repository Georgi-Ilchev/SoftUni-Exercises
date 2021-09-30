function solve() {
   document.getElementsByClassName('shopping-cart')[0].addEventListener('click', onClick);
   let button = document.getElementsByClassName('checkout')[0].addEventListener('click', checkout);

   const cart = [];
   const output = document.getElementsByTagName('textarea')[0];

   function onClick(ev) {
      if (ev.target.tagName == 'BUTTON' &&
         ev.target.classList.contains('add-product')) {
         const product = ev.target.parentNode.parentNode;
         const name = product.querySelector('.product-title').textContent;
         const price = Number(product.querySelector('.product-line-price').textContent);

         cart.push({
            name,
            price
         });


         output.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
      }
   }

   function checkout() {
      const products = new Set();
      cart.forEach(p => products.add(p.name));

      const total = cart.reduce((t, c) => t + c.price, 0);

      output.value += `You bought ${[...products.keys()].join(', ')} for ${total.toFixed(2)}.`;
      disableButtons();
   }

   function disableButtons() {
      let buttons = Array.from(document.querySelectorAll('button'));
      buttons.forEach(button => button.disabled = true);
   }
}