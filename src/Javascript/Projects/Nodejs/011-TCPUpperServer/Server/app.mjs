import net from 'net';
import {writeErrLine, writeLine} from '../../../../../Javascript/csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function clientCallback(socket, data)
{
    const message = data.toString().trim()
    writeLine(`Length: ${message.length}, Message: [${message}]`)
    socket.write(`${message.toUpperCase()}\r\n`)
    socket.destroy()
}

function handleClientCallback(socket)
{
    socket.on("data", data => clientCallback(socket, data))
    socket.on("close", () => writeErrLine("Client disconnected"))
}

function main()
{
    let port = Number(process.argv[2])

    if (isNaN(port))
        port = 50505

    const server = net.createServer(handleClientCallback)

    writeLine(`Server is listening on port:${port}`)
    server.listen(port)
}

main()
