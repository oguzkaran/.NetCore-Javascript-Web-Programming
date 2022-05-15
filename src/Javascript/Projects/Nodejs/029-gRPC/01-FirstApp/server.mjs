import grpc from '@grpc/grpc-js';
import protoLoader from '@grpc/proto-loader'
import {writeLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => console.log(err.message))

let packageDef = protoLoader.loadSync("todo.proto")
const todoProto = grpc.loadPackageDefinition(packageDef)
const server = new grpc.Server();

let todos = [
    { id: "1", title: "Market", description: "Domates, Salatalık", completed: true},
    { id: "2", title: "Eczane", description: "Vitamin, Aspirin", completed: false},
]

server.addService(todoProto.TodoService.service, {
    findAllTodos: (_, cb) => cb(null, todos)
});

server.bindAsync(
    "192.168.1.100:50500", grpc.ServerCredentials.createInsecure(),
    (err, port) => {
        if (err)
            throw err

        writeLine("Server is running")
        server.start()
    }
)



