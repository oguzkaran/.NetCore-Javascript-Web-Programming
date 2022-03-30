import net from 'net'
import dgram from 'dgram'
import {writeLine, writeErrLine} from '../../../../csd-modules/csdstdioutil.mjs'
import {randomTextTR} from '../../../../csd-modules/csdstringutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function sendMessage(port, host, msg)
{
    const socket = net.connect(port, host, () => writeLine("Connection established!..."))

    socket.on("connect", () => socket.write(`${msg}\r\n`))
    socket.on("data", data => writeLine(`Message:${data.toString().trim()}`))
}

function severInfCallback(data, ri)
{
    const port = Number(data.toString().trim())
    const msg = randomTextTR(10)

    writeLine(`Server Info: ${ri.address}:${port}`)
    writeLine(`Message:${msg}`)
    sendMessage(port, ri.address, msg)
}

function startServerInfoReceiver(socket, port)
{
    socket.on("message", severInfCallback)
    socket.on("listening", () => writeLine(`"ServerInfo Receiver" is listening on port:${port}`))
    socket.bind(port)
}

function main()
{
    const udpPort = process.argv[2];
    const serverInfoReceiver = dgram.createSocket('udp4')
    startServerInfoReceiver(serverInfoReceiver, udpPort)
}

main()



