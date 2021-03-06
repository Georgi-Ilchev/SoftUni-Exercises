//100 points
function solve() {
   let p1CardIndex = null;
   let p2CardIndex = null;

   let p1CardValue = null;
   let p2CardValue = null;

   let cardHistory = [];
   let images = document.querySelectorAll('section.cards img');

   for (let i = 0; i < images.length; i++) {
      images[i].addEventListener('click', function (e) {
         let currentImg = e.target;
         currentImg.src = 'images/whiteCard.jpg';
         let imgName = +currentImg.name;

         let parentId = e.target.parentElement.id;
         if (parentId === 'player1Div') {
            let player1Result = document.getElementsByTagName('span')[0];
            player1Result.textContent = imgName;
            p1CardValue = imgName;
            p1CardIndex = i;
         } else if (parentId === 'player2Div') {
            let player2Result = document.getElementsByTagName('span')[2];
            player2Result.textContent = imgName;
            p2CardValue = imgName;
            p2CardIndex = i;
         }

         if (p1CardIndex !== null && p2CardIndex !== null) {
            if (p1CardValue > p2CardValue) {
               images[p1CardIndex].style.border = '2px solid green';
               images[p2CardIndex].style.border = '2px solid red';
            } else if (p1CardValue < p2CardValue) {
               images[p1CardIndex].style.border = '2px solid red';
               images[p2CardIndex].style.border = '2px solid green';
            }

            cardHistory.push(`[${p1CardValue} vs ${p2CardValue}]`);

            p1CardIndex = null;
            p2CardIndex = null;

            p1CardValue = null;
            p2CardValue = null;

            let history = document.getElementById('history');
            history.textContent = cardHistory.join(' ') + ' ';
         }
      })
   }
}



//16 points
function solve() {
   let player1Cards = document.getElementById('player1Div');
   let player2Cards = document.getElementById('player2Div');

   let history = document.querySelector('#history');
   let cardHistory = [];

   let spanElements = document.querySelectorAll('div > span');
   let firstPlayerCardSpan = spanElements[0];
   let secondPlayerCardSpan = spanElements[2];

   let p1CardValue;
   let p2CardValue;

   let currentFirstPlayerCard;
   let currentSecondPlayerCard;

   player1Cards.addEventListener('click', (e) => {
      e.target.src = 'images/whiteCard.jpg';

      firstPlayerCardSpan.innerHTML = e.target.name;
      p1CardValue = Number(e.target.name);
      currentFirstPlayerCard = e.target;

      if (secondPlayerCardSpan.innerHTML !== null) {
         p2CardValue = Number(secondPlayerCardSpan.innerHTML);
         cardHistory.push(`[${p1CardValue} vs ${p2CardValue}] `);
      }

      if (p1CardValue > p2CardValue) {
         currentFirstPlayerCard.style.border = '2px solid green';
         currentSecondPlayerCard.style.border = '2px solid red';
      } else {
         currentFirstPlayerCard.style.border = '2px solid red';
         currentSecondPlayerCard.style.border = '2px solid green';
      }
   });

   player2Cards.addEventListener('click', (e) => {
      e.target.src = 'images/whiteCard.jpg';

      secondPlayerCardSpan.innerHTML = e.target.name;
      p2CardValue = Number(e.target.name);
      currentSecondPlayerCard = e.target;

      if (firstPlayerCardSpan.innerHTML !== null) {
         p1CardValue = Number(firstPlayerCardSpan.innerHTML);
         cardHistory.push(`[${p1CardValue} vs ${p2CardValue}] `);
      }

      if (p1CardValue < p2CardValue) {
         currentFirstPlayerCard.style.border = '2px solid red';
         currentSecondPlayerCard.style.border = '2px solid green';
      } else {
         currentFirstPlayerCard.style.border = '2px solid green';
         currentSecondPlayerCard.style.border = '2px solid red';
      }

      history.textContent += (`[${p1CardValue} vs ${p2CardValue}] `);
   });

   history.innerHTML = cardHistory.join(' ') + ' ';
}