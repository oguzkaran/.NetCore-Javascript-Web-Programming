import dgram from 'dgram'
import {writeErrLine, writeLine} from '../../../../csd-modules/csdstdioutil.mjs'
import {randomTextTR} from '../../../../csd-modules/csdstringutil.mjs'
import {Random} from '../../../../csd-modules/csdrandom.mjs'

process.on("uncaughtException", err => writeErrLine(`Message: ${err.message}`))


function sendMessage(port, host, client)
{
    const msg = randomTextTR(Random.nextInt(10, 15))
    writeLine(msg)
    client.send(msg + '\r\n', port, host, err => {if (err) throw err})
}


function main()
{
    const host = process.argv[2]
    const port = Number(process.argv[3])
    const client = dgram.createSocket("udp4")

    setInterval(() => sendMessage(port, host, client), 400)
}

main()
