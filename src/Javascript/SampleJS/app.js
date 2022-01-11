function write(a)
{
    process.stdout.write(a)
}

function writeln(a)
{
    write(a === undefined ? '\n' : `${a}\n`)
}

function main()
{
    let display = (...args) => {
        writeln(`Arguments:${args.length}`)
        for (let elem of args)
            writeln(elem)
    }

    display(10, 20, 30)
    writeln("/////////")
    display(10)
}

main()


