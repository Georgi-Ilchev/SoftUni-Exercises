(function arrayExtension() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (number) {
        //1
        // return this.slice(number);

        //2
        const result = [];
        for (let i = number; i < this.length; i++) {
            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.take = function (number) {
        //1
        // return this.slice(0, number);

        //2
        const result = [];
        for (let i = 0; i < number; i++) {
            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.sum = function () {
        return this.reduce((acc, x) => acc + x, 0);
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})();