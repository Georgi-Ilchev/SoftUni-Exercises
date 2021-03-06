const { SortedList: SrList } = require('./18. Sorted List.js');

function solve() {
    let list = new SrList();

    list.add(5);
    list.add(6);
    list.add(7);
    console.log(list.get(1));
    list.remove(1);
    console.log(list.get(1));

    console.log(list);
}

solve();
