function createSortedList() {
    const list = [];
    return {
        add(num) {
            if (typeof (num) === 'number') {
                list.push(num);
                list.sort((a, b) => a - b);
            } else {
                console.log('The array takes only numbers.')
            }
        },
        remove(index) {
            if (index >= 0 && index < list.length) {
                list.splice(index, 1);
            } else {
                console.error('The index is outside the bounds of the array');
            }
        },
        get(index) {
            if (index >= 0 && index < list.length) {
                return list[index];
            } else {
                console.error('The index is outside the bounds of the array');
            }
        },
        get size() {
            return list.length
        }
    }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));