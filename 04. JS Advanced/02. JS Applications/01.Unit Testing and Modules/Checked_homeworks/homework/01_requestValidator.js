function validator(obj) {
    const validMethods = ['POST', 'GET', 'DELETE', 'CONNECT'];
    const validHTTP = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0']


    function checkMethod(object) {
        if (!validMethods.includes(object.method)) {
            return false;
        } else {
            return true;
        }

    }

    function checkuri(object) {
        let pattern = /[a-zA-Z0-9]+\.?[a-zA-Z0-9]+\.?|\*/g;

        if (pattern.test(object.uri) && object.uri !== '') {
            return true;
        } else {
            return false;
        }


    }

    function checkVersion(object) {
        if (!validHTTP.includes(object.version)) {
            return false;
        } else {
            return true;
        }
    }

    function checkMessage(object) {
        let pattern = /^([^<>\\&'"]*)$/g;
        if (pattern.exec(object.message) || object.message === '') {
            if (!object.hasOwnProperty('message')) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
    let test = false;
    if (checkMethod(obj) && obj.hasOwnProperty('method')) {
        test = true;
    } else {
        throw new Error('Invalid request header: Invalid Method');
    }
    if (checkuri(obj) && obj.hasOwnProperty('uri')) {
        test = true;
    } else {
        throw new Error('Invalid request header: Invalid URI');
    }
    if (checkVersion(obj) && obj.hasOwnProperty('version')) {
        test = true;
    } else {
        throw new Error('Invalid request header: Invalid Version');
    }
    if (checkMessage(obj) && obj.hasOwnProperty('message')) {
        test = true;
    } else {
        throw new Error('Invalid request header: Invalid Message');
    }
    return obj
}
console.log(validator({
    method: 'POST',
    uri: 'home.bash',
    version: 'HTTP/0.9',
    message: 'AAAAA>>>>'
}))