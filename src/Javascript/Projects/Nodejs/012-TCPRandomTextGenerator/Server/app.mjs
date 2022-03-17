import net from 'net';
import {writeErrLine, writeLine} from '../../../../../Javascript/csd-modules/csdstdioutil.mjs'
import {randomTextTR} from '../../../../../Javascript/csd-modules/csdstringutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function clientCallback(socket, data)
{
    const count = parseInt(data)
    //writeLine(`Count: ${count}`)
    for (let i = 0; i < count; ++i)
        socket.write(randomTextTR(10) + '\r\n')

    socket.destroy()
}

function handleClientCallback(socket)
{
    socket.on("data", data => clientCallback(socket, data))
    socket.on("close", () => {})
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
