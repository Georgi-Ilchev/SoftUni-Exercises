function extensibleObject() {
    let proto = {};
    let extensibleObject = Object.create(proto);

    extensibleObject.extend = function (template) {
        //1
        for (const key in template) {
            if (typeof template[key] === 'function') {
                let proto = Object.getPrototypeOf(this);
                proto[key] = template[key];
            } else {
                this[key] = template[key];
            }
        }

        //2
        // Object.entries(template).forEach(([key, value]) => {
        //     if (typeof value === 'function') {
        //         proto[key] = value;
        //     } else {
        //         extensibleObject[key] = value;
        //     }
        // });
    }

    return extensibleObject;
}

const myObj = extensibleObject();

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
myObj.extend(template);

console.log(myObj);