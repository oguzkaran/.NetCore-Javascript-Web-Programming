function write(a)
{
    process.stdout.write(a)
}

function writeln(a)
{
    write(a === undefined ? '\n' : `${a}\n`)
}

function randomInt(min, max)
{
    return Math.floor(Math.random() * (max - min)) + min + 1
}

function countValue(array, value)
{
    let count = 0

    array.forEach(e => {if (e === value) ++count})

    return count
}

function generateRandomArray(count, min, max)
{
    let array = []

    for (let i = 0; i < count; ++i)
        array[i] = randomInt(min, max)

    return array
}

function main()
{
    let a = generateRandomArray(40, -10, 10)

    let count = countValue(a, 0)

    writeln(a)

    writeln(`Count:${count}`)
}

main()

