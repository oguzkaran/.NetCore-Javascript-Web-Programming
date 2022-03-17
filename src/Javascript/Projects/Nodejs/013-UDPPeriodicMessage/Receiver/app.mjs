import dgram from 'dgram'
import {writeErrLine, writeLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(`Message: ${err.message}`))

function udpMessageCallback(data, ri)
{
    const msg = data.toString()
    writeLine(`${msg.length} byte received ${ri.adress}:${ri.port}: ${msg}`)
}


function main()
{
    const server = dgram.createSocket("udp4")
    const port = Number(process.argv[2])
    server.on("message", udpMessageCallback)
    server.on("listening", () => writeLine(`Receiver listening on port:${port}`))
    server.bind(port)
}

main()

