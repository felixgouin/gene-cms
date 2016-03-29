var edge = require('edge');

var helloFs = edge.func('fs', function () {/*
    fun input -> async { 
        return "F# welcomes " + input.ToString()
    }
*/});

helloFs('Node.js', function (error, result) {
    if (error) throw error;
    console.log(result);
});