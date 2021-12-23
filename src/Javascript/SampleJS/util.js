exports.onKeyboard = function (callback, msg) {
    process.stdin.on("readable", function () {
        process.stdout.write(msg);
        var chunk = process.stdin.read();

        if (chunk != null)
            callback(chunk);
    });
}

exports.write = function (a) {
    process.stdout.write(a)
}

exports.writeln = function (a) {
    exports.write(a + "\n")
}

exports.readInt = function (msg, errMsg) {
    exports.write(msg)

    for (;;) {
        let data = process.stdin.read()

        if (data == null)
            return null

        let val = Number(data)

        if (!isNaN(val))
            return val

        exports.write(errMsg)
    }
}

exports.readIntLine = function (msg, errMsg) {
    return exports.readInt(msg + "\n", errMsg + "\n")
}

exports.listenAllExceptions = function (cb) {
    process.on("uncaughtException", cb)
}