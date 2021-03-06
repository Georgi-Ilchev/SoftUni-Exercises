function solve(input) {
    let splittedArray = input[0].split(/\W+/).filter(w => w != "");
    let wordCounter = {};

    for (let word of splittedArray) {
        if (!wordCounter.hasOwnProperty(word)) {
            wordCounter[word] = 1;
        } else {
            wordCounter[word]++;
        }
    }

    console.log(JSON.stringify(wordCounter));
}
solve([`Far too slow, you're far too slow.`])
solve(['JS devs use Node.js for server-side JS.-- JS for devs'])