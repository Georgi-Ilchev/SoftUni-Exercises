function solve() {
   let money = 0;
   let shoppingCart = [];
   let endShopping = false;
   let output = document.querySelector('body > div > textarea');

   Object.values(document.getElementsByTagName('button')).map(b => b.addEventListener('click', function (t) {
      let clickedButton = t.target.className;

      if (clickedButton === 'add-product' && !endShopping) {
         addItem(t);
      } else if (clickedButton === 'checkout' && !endShopping) {
         breakShopping();
      }
   }));

   function addItem(t) {
      let items = productsList();
      let item = t.target.parentNode.parentNode.children[1].children[0].textContent;
      let info = `Added ${item} for ${items[item].toFixed(2)} to the cart.`;
      productsCart(items, item);
      printResult(info);
   }

   function breakShopping() {
      let info = `You bought ${shoppingCart.join(', ')} for ${money.toFixed(2)}.`;
      endShopping = true;
      printResult(info);
   }

   function productsCart(items, item) {
      money += items[item];
      if (!shoppingCart.includes(item)) {
         shoppingCart.push(item);
      }
   }

   function productsList() {
      let products = {
         'Bread': 0.80,
         'Milk': 1.09,
         'Tomatoes': 0.99,
      }
      return products;
   }

   function printResult(info) {
      output.textContent += `${info}\n`;
   }
}