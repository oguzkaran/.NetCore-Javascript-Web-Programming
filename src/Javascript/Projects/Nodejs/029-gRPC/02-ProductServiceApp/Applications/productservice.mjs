let products = [
    {
        id: "12345678899",
        name: "laptop",
        stock: 123,
        cost: 10000.89,
        unitPrice: 15000.56
    },
    {
        id: "1234567886789",
        name: "mouse",
        stock: 300,
        cost: 100.89,
        unitPrice: 150.56
    },
    {
        id: "5676u8w7438",
        name: "keyboard",
        stock: 300,
        cost: 1200.89,
        unitPrice: 2200.56
    }
]

function findAllProducts()
{
    return products
}

function saveProduct(p)
{
    products.push(p)
}

function deleteAllProducts()
{
    //...
}

export {findAllProducts, saveProduct, deleteAllProducts}
