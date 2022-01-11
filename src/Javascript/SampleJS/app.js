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
    return Math.floor(Math.random() * (max - min) + min + 1)
}

function randomDouble(min, max)
{
    return Math.random() * (max - min) + min
}

function randomText(n, text)
{
    let str = ""
    let len = text.length;

    for (let i = 0; i < n; ++i)
        str += text.charAt(randomInt(0, len))

    return str
}

function randomTextTR(n)
{
    return randomText(n, "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz")
}


function randomTextsTR(n, min, max)
{
    let result = [];

    while (n--)
        result.push(randomTextTR(randomInt(min, max)))

    return result
}


function randomTextEN(n)
{
    return randomText(n, "ABCDEFGHIJKLMNOPQRSTUWXVYZabcdefghijklmnopqrstuwxvyz")
}

function randomTextsEN(n, min, max)
{
    let result = [];

    while (n--)
        result.push(randomTextEN(randomInt(min, max)))

    return result
}

let Product = function (id, name, stock, cost, price) {
    this.id = id
    this.name = name;
    this.stock = stock
    this.cost = cost
    this.price = price
    this.getTotal = function () {return this.stock * this.price}
    this.getTotalCost = function () {return this.stock * this.cost}
    this.toString = function () {
        return JSON.stringify(this)
    }
}

function createRandomProduct(id)
{
    let name = randomTextTR(randomInt(5, 15))
    let stock = randomInt(-100, 100)
    let cost = randomDouble(34.7, 109.45)
    let price = randomDouble(34.7, 109.45)

    return new Product(id, name, stock, cost, price)
}

function createRandomProducts(n)
{
    let products = []

    for (let i = 1; i <= n; ++i)
        products.push(createRandomProduct(i))

    return products
}

function main()
{
    let products = createRandomProducts(10)

    products.forEach(writeln)
    writeln("-------------------------")
    products.filter(p => p.stock > 0).sort((p1, p2) => p2.price - p1.price).forEach(writeln)
    writeln("-------------------------")
    products.filter(p => p.stock < 0).sort((p1, p2) => p1.getTotal()- p2.getTotal()).forEach(writeln)

}

main()
