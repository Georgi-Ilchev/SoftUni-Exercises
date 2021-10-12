(function stringExtension() {
    String.prototype.ensureStart = function (str) {
        //1
        if (!this.startsWith(str)) {
            return str + this;
        }

        return this.toString();

        //2
        // if (this.slice(0, str.length) === str) {
        //     return this.toString();
        // }
        // return str + this;
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function () {
        return this.toString() === '' ? true : false;
    };

    String.prototype.truncate = function (n) {
        //1
        if (this.length <= n) {
            return this.toString();
        } else if (this.length < 4) {
            return '.'.repeat(n);
        } else if (this.length > n) {
            let isSpaces = this.split(' ').length > 1;

            if (isSpaces) {
                let index = this.substring(0, n).trim().lastIndexOf(' ');

                if (index != -1) {
                    return this.substring(0, index) + '...';
                } else {
                    return this.substring(0, n) + '...';
                }
            } else {
                n = this.endsWith('...') ? n + 3 : n;
                return this.slice(0, -n) + '...';
            }
        }

        //2
        // if (this.length <= n) {
        //     return this.toString();
        // }

        // if (this.includes(' ')) {
        //     let words = this.split(' ');

        //     do {
        //         words.pop();
        //     } while (words.join(' ').length + 3 > n);

        //     let sentence = `${words.join(' ')}...`;

        //     return sentence;
        // }

        // if (n > 3) {
        //     let string = `${this.slice(0, n - 3)}...`;
        //     return string;
        // }

        // return '.'.repeat(n);
    };

    String.format = function (str, ...params) {
        //1
        // let replaceRegex = /{(\d+)}/g;

        // let replacedStr = str.replace(replaceRegex, (match, group1) => {
        //     let index = Number(group1);
        //     if (params[index] !== undefined) {
        //         return params[index];
        //     }

        //     return match;
        // });

        // return replacedStr;

        //2
        params.forEach((el, i) => {
            if (str.includes(`{${i}}`)) {
                str = str.replace(`{${i}}`, el);
            }
        })
        return str;
    };
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');
