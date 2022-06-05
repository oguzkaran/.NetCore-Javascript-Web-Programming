import grpc from '@grpc/grpc-js'
import protoLoader from '@grpc/proto-loader'

const PROTO_PATH = "./product.proto"
const options = {
    longs: String,
    oneofs: true,
    keepCase: true,
    enums: String,
    defaults: true,
}

const packageDefinition = protoLoader.loadSync(PROTO_PATH, options)
const productProto = grpc.loadPackageDefinition(packageDefinition)

export {productProto}
