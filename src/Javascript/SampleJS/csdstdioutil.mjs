const write = a => process.stdout.write(a)
const writeln = a => write(a === undefined ? '\n' : `${a}\n`)
const writeLine = a => writeln(a)

export {write, writeln, writeLine}


