class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2) {
        let xOffset = Math.abs(p1.x - p2.x);
        let yOffset = Math.abs(p1.y - p2.y);

        let distance = Math.sqrt(xOffset ** 2 + yOffset ** 2);
        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
