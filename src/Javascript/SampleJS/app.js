function write(a)
{
    process.stdout.write(a)
}

function writeln(a)
{
    write(a === undefined ? '\n' : `${a}\n`)
}

function writeLine()
{
    for (let arg of arguments)
        writeln(`${arg}`)
}

function sum()
{
    let total = 0

    for (let val of arguments)
        total += val

    return total
}

function main()
{
    writeLine(10, 20, 30)
    writeLine(10)
    writeln(sum(10, 20, 30))
    writeln(sum(10))
    writeln(sum())
}

main()
