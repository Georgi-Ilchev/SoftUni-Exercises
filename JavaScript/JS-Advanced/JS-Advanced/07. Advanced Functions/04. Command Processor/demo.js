function solution() {
    let text = '';

    return {
        append: x => text += x,
        removeStart: n => text = text.substr(n),
        removeEnd: n => text = text.substr(0, text.length - n),
        print: () => console.log(text),
    };
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();


let secondZeroTest = solution();
secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();
