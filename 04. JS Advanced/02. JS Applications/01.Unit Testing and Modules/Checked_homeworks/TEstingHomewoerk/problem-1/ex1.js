function requestValidate(request) {

    let methods = ['GET', 'POST', 'DELETE','CONNECT'];
    let patternUri = /^[A-Za-z*\.\d]+$/g;
    let version = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1','HTTP/2.0'];
    let patternMess = /^([^<>\\&'"]*)$/g;

    if(!methods.includes(request.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if(!request.uri.match(patternUri)){
        throw new Error('Invalid request header: Invalid URI');
    }

    if(!version.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if(!request.message.match(patternMess)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return request;
}

requestValidate({
    method: 'POST',
    version: 'HTTP/2.0',
    message: 'rm -rf /*'
}
)