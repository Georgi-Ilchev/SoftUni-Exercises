class Rectangle {
    constructor(width, height, color) {
        this.width = Number(width);
        this.height = Number(height);
        this.color = color;
    }

    calcArea() {
        let result = 0;
        result = Number(this.width) * Number(this.height);

        return result;
    }
}

function solve() {
    let rect = new Rectangle(4, 5, 'red');
    console.log(rect.width);
    console.log(rect.height);
    console.log(rect.color);
    console.log(rect.calcArea());
}
solve();