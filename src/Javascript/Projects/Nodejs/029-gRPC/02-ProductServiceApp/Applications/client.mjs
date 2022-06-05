import grpc from '@grpc/grpc-js'
import {writeLine, writeErrLine} from '../../../../../csd-modules/csdstdioutil.mjs'
import {productProto} from "./productproto.mjs";

process.on("uncaughtException", err => writeErrLine(err.message))

const ProductService = productProto.ProductService
const client = new ProductService("192.168.1.109:50500", grpc.credentials.createInsecure())
client.findAllProducts(null, (err, data) => {
    if (err)
        throw err

    writeLine(JSON.stringify(data))
})
client.deleteAllProducts(null, err => {
    if (err)
        throw err
    writeLine("Deleted")
})

client.saveProduct({
    id: "5676u8w7435",
    name: "phone",
    stock: 400,
    cost: 12000.89,
    unitPrice: 22000.56
}, (err, data) => {
    if (err)
        throw err

    writeLine(JSON.stringify(data))
})



