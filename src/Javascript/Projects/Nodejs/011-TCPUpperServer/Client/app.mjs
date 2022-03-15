import net from 'net';
import {writeErrLine, writeLine} from '../../../../../Javascript/csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function doWorkForMessage(host, port, message)
{
    const socket = net.connect(port, host, () => {})

    socket.on("connect", () => socket.write(`${message}\r\n`))
    socket.on("data", data => writeLine(`Length: ${data.length}, Message: [${data.toString().trim()}]`))
}

function main()
{
    const host = process.argv[2]
    let port = Number(process.argv[3])

    if (isNaN(port))
        port = 50505

    for (let i = 0; i < 10; ++i)
        doWorkForMessage(host, port, "merhaba")
}

main()
