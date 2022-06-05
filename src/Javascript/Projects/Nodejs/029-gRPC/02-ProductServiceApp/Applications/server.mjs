import grpc from '@grpc/grpc-js'
import {deleteAllProducts, findAllProducts, saveProduct} from "./productservice.mjs";
import {writeLine} from '../../../../../csd-modules/csdstdioutil.mjs'
import {productProto} from "./productproto.mjs";


const server = new grpc.Server()
const products = findAllProducts()

server.addService(productProto.ProductService.service, {
    findAllProducts: (_, callback) => {
        callback(null, {products})
    },

    saveProduct: (call, callback) => {
        const p = call.request

        saveProduct(p)
        callback(null, products)
    },

    deleteAllProducts: (_, callback) => {
        deleteAllProducts()
        callback(null, null)
    }
})

server.bindAsync(
    "192.168.1.109:50500", grpc.ServerCredentials.createInsecure(),
    (err, port) => {
        if (err)
            throw err

        writeLine("Server is running")
        server.start()
    }
)





