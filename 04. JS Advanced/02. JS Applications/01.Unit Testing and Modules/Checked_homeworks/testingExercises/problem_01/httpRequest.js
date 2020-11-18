function httpRequest(request) {
    let methods = ['POST', 'GET', 'DELETE', 'CONNECT'];
    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    let URIRegExp = /^([A-Za-z0-9\.]+|\*)$/g;
    let messageRegExp = /^([^<>\\&'"]*)$/g;

    if (!request.hasOwnProperty('method') || !methods.includes(request.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!request.hasOwnProperty('uri') || !request.uri.match(URIRegExp)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!request.hasOwnProperty('version') || !versions.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!request.hasOwnProperty('message') || !request.message.match(messageRegExp)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return request;
}

httpRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});

// httpRequest({
//     method: 'OPTIONS',
//     uri: 'git.master',
//     version: 'HTTP/1.1',
//     message: '-recursive'
// });

// httpRequest({
//     method: 'POST',
//     uri: 'home.bash',
//     message: 'rm -rf /*'
// });