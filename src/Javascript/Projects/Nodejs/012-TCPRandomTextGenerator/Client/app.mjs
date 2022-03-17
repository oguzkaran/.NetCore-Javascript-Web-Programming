import net from 'net';
import {writeErrLine, writeLine} from '../../../../../Javascript/csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function doWorkForCount(host, port, count)
{
    const socket = net.connect(port, host, () => {})
    socket.on("connect", () => socket.write(count.toString()))
    socket.on("data", data => writeLine(data.toString()))
}

function main()
{
    const host = process.argv[2]
    let port = Number(process.argv[3])

    if (isNaN(port))
        port = 50505

    for (let i = 0; i < 10; ++i)
        doWorkForCount(host, port, (i + 1) * 2)
}

main()
