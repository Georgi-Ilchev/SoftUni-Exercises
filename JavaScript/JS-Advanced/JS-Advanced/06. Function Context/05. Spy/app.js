function Spy(target, methodName) {
    let result = {
        count: 0,
    }

    let originalMethod = target[methodName];

    target[methodName] = function (...params) {
        result.count++;

        //return originalMethod(...params);
        //or
        // return originalMethod.apply(target, params);
        //or
        return originalMethod.call(target, ...params);
    };

    //or

    // target[methodName] = function () {
    //     result.count++;

    //     return originalMethod.apply(target, arguments);
    //     //or
    //     //return originalMethod.call(target, ...arguments);
    // };

    return result;
}


let obj = {
    method: () => "invoked"
}
let spy = Spy(obj, "method");

obj.method();
obj.method();
obj.method();

console.log(spy) // { count: 3 }
