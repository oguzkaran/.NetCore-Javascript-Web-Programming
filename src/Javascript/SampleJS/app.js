function write(a)
{
    process.stdout.write(a)
}

function writeln(a)
{
    write(a === undefined ? '\n' : `${a}\n`)
}

let Product = function (name, price, stock)
{
    this.name = name
    this.price = price
    this.stock = stock
    this.getTotal =  function () {return this.stock * this.price }
}

function main()
{
    let products = new Array()

    products.push(new Product("laptop", 4000, 0))
    products.push(new Product("mouse", 40, 349))
    products.push(new Product("klavye", 30, 0))
    products.push(new Product("kalem", 40, 34))

    let productsNotInStock = new Array(products.length)

    let index = -1

    while (true) {
        index = products.findIndex((p, i) => i >= index + 1 && p.stock <= 0)

        if (index === -1)
            break

        productsNotInStock.push(products[index])
    }

    productsNotInStock.forEach(p => writeln(p.name))
}
main()
