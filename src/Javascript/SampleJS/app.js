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

function toString()
{
    return `${this.name}:${this.stock * this.price}`
}

function main()
{
    let products = [
        { name: "laptop", stock: 6, price: 4345, toString: toString },
        { name: "mouse", stock: 40, price: 70, toString: toString },
        { name: "motherboard", stock: 5, price: 500, toString: toString },
    ]

    for (let p of products)
        writeln(p.toString())
}

main()
