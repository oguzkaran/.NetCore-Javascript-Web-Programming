import net from 'net'
import dgram from 'dgram'

import {writeLine, writeErrLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function getPorts()
{
    const host =  process.argv[2]
    let tcpPort = Number(process.argv[3]);

    if (isNaN(tcpPort))
        tcpPort = 50500

    let udpPort = Number(process.argv[4]);

    if (isNaN(udpPort))
        udpPort = 50501

    return [host, tcpPort, udpPort];
}

function upperServerCallback(data, socket)
{
    let message = data.toString().trim();

    writeLine(`Message:${message}`)
    message = message.toUpperCase()
    writeLine(`Upper message:${message}`)

    socket.write(`${message}\r\n`)
}

function createUpperServerCallback(socket)
{
    socket.on("data", data => upperServerCallback(data, socket))
}

function startUpperServer(server, port)
{
    writeLine(`Upper server is listening on port:${port}`)
    server.listen(port)
}

const sendMessage = (socket, port, host, message) => socket.send(message, port, host, err => {if (err) throw err})

function main()
{
    const [host, tcpPort, udpPort] = getPorts();

    const upperServer = net.createServer(s =>  createUpperServerCallback(s))
    const sendInfoSocket = dgram.createSocket('udp4')

    sendMessage(sendInfoSocket, udpPort, host, `${tcpPort}\r\n`)
    startUpperServer(upperServer,tcpPort)
}

main()
