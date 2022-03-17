import dgram from 'dgram'
import {writeErrLine, writeLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine(`Message: ${err.message}`))


function sendMessage(msg, port, host, client)
{
    client.send(msg, port, host, err => {if (err) throw err})
}


function main()
{
    const host = process.argv[2]
    const port = Number(process.argv[3])
    const client = dgram.createSocket("udp4")

    setInterval(() => sendMessage("I am Ok\r\n", port, host, client), 400)
}

main()
