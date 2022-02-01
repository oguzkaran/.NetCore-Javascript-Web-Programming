exports.write = a => process.stdout.write(a)
exports.writeLine = a => exports.write(a === undefined ? '\n' : `${a}\n`)
const writeErr = a => process.stderr.write(a)
const writeErrLine = a => writeErr(a === undefined ? '\n' : `${a}\n`)
const readLoop = action => process.stdin.on("data", data =>  action(data))




