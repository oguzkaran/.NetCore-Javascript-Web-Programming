import net from 'net';
import {writeErrLine, writeLine} from '../../../../../Javascript/csd-modules/csdstdioutil.mjs'
import {randomTextTR} from '../../../../../Javascript/csd-modules/csdstringutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function clientCallback(socket, data, upperBound)
{
    const count = parseInt(data)

    if (0 < count && count <= upperBound) {
        //writeLine(`Count: ${count}`)
        socket.write(1 + '\r\n')
        for (let i = 0; i < count; ++i)
            socket.write(randomTextTR(10) + '\r\n')
    }
    else
        socket.write(0 + '\r\n')

    socket.destroy()
}

function handleClientCallback(socket, upperBound)
{
    socket.on("data", data => clientCallback(socket, data, upperBound))
    socket.on("close", () => {})
}

function main()
{
    let port = Number(process.argv[2])
    let upperBound = Number(process.argv[3])

    if (isNaN(port))
        port = 50505

    const server = net.createServer(socket => handleClientCallback(socket, upperBound))

    writeLine(`Server is listening on port:${port}`)
    server.listen(port)
}

main()
