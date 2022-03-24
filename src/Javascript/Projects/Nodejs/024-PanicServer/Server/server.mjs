import net from 'net'
import dgram from 'dgram'

import {writeLine, writeErrLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

function getPorts()
{
    let tcpPort = Number(process.argv[2]);

    if (isNaN(tcpPort))
        tcpPort = 50500

    let udpPort = Number(process.argv[3]);

    if (isNaN(udpPort))
        udpPort = 50501

    return [tcpPort, udpPort];
}

function reportOKCallback(data, ri)
{
    const message = data.toString().trim();

    writeLine(`Message:${message} from ${ri.address}`)
}

function panicServerCallback(data, socket)
{
    const message = data.toString().trim();

    writeLine(`Panic Message:${message}`)
    socket.write('Do not panic!...')
}

function createPanicServerCallback(socket)
{
    socket.on("data", data => panicServerCallback(data, socket))
}

function startReceiverForReport(socket, port)
{
    socket.on("message", reportOKCallback)
    socket.on("listening", () => writeLine(`Report server is listening on port:${port}`))
    socket.bind(port)
}

function startServerPanic(server, port)
{
    writeLine(`Panic server is listening on port:${port}`)
    server.listen(port)
}


function main()
{
    const [tcpPort, udpPort] = getPorts();

    const panicServer = net.createServer(s =>  createPanicServerCallback(s))
    const periodicMessageSocket = dgram.createSocket('udp4')

    startReceiverForReport(periodicMessageSocket, udpPort)
    startServerPanic(panicServer,tcpPort)
}

main()
