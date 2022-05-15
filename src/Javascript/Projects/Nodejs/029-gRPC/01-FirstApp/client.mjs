import grpc from '@grpc/grpc-js';
import protoLoader from '@grpc/proto-loader'

process.on("uncaughtException", err => console.log(err.message))

let packageDef = protoLoader.loadSync("todo.proto")
const TodoService = grpc.loadPackageDefinition(packageDef).TodoService

const client = new TodoService("192.168.1.100:50500", grpc.credentials.createInsecure())

client.findAllTodos({}, (err, todos) => {
    if (err)
        throw err

    console.log(todos)
})



