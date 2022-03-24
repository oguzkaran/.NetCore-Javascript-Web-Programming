import net from 'net'
import dgram from 'dgram'

import {writeLine, writeErrLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function getServerInfo()
{
    const host = process.argv[2]
    let tcpPort = Number(process.argv[3]);

    if (isNaN(tcpPort))
        tcpPort = 50500

    let udpPort = Number(process.argv[4]);

    if (isNaN(udpPort))
        udpPort = 50501

    return [host, tcpPort, udpPort];
}

const sendMessage = (socket, port, host, message) => socket.send(message, port, host, err => {if (err) throw err})

function sendPanicMessage(port, host, msg)
{
    const socket = net.connect(port, host, () => writeLine("Connection established!..."))

    socket.on("connect", () => socket.write(`${msg}\r\n`))
    socket.on("data", data => writeLine(`Message:${data.toString().trim()}`))
}

function main()
{
    const [host, tcpPort, udpPort] = getServerInfo()
    const dgramSocket = dgram.createSocket("udp4")
    setInterval(() => sendMessage(dgramSocket, udpPort, host, "I am OK!...\r\n"), 1000)
    setInterval(() => sendPanicMessage(tcpPort, host, "Panic!...."), 4000)
}

main()
