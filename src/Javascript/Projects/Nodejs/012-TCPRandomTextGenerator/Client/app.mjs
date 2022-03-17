import net from 'net';
import {writeErrLine, writeLine} from '../../../../../Javascript/csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function doWorkForCount(host, port, count)
{
    const socket = net.connect(port, host, () => {})
    socket.on("connect", () => socket.write(count.toString()))
    socket.on("data", data => writeLine(data.toString().trim()))
    socket.on("close", () => writeLine("Socket closed by server"))
}

function main()
{
    const host = process.argv[2]
    let port = Number(process.argv[3])

    if (isNaN(port))
        port = 50505


    doWorkForCount(host, port, Number(process.argv[4]))
}

main()
