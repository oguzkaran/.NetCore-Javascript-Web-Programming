import http from 'http';
import {writeLine, writeErrLine} from '../../../csd-modules/csdstdioutil.mjs'
import {MessageInfo} from "./messageinfo.mjs";
import {remoteAddress} from '../../../csd-modules/csdhttputil.mjs'
import {createMongoClient} from '../../../csd-modules/csdmongodbutil.mjs'


process.on("uncaughtException", err => writeErrLine(err))

const msgInfo = new MessageInfo("")

function connectForInsertCallback(err, client, req, msg)
{
    if (err)
        throw  err

    const db = client.db(process.argv[4])
    const clients = db.collection(process.argv[5])
    writeErrLine(remoteAddress(req))
    const record = {host: remoteAddress(req), time: new Date().toString(), url: msg}
    clients.insertOne(record, err => {if (err) throw err})
}

function saveAddress(req, msg)
{
    const host = process.argv[2]
    const port = parseInt(process.argv[3])

    createMongoClient(host, port).connect((err, client) => connectForInsertCallback(err, client, req, msg))
}

function helloUrlCallback(req, res)
{
    saveAddress(req, req.url)
    res.writeHead(200, {'Content-Type':'application/json'})
    msgInfo.message = "Root Url"
    res.end(msgInfo.toString())
}

function helloTRUrlCallback(req, res)
{
    saveAddress(req, req.url)
    res.writeHead(200, {'Content-Type':'application/json'})
    msgInfo.message = "Merhaba arkadaşlar"
    res.end(msgInfo.toString())
}

function helloENUrlCallback(req, res)
{
    saveAddress(req, req.url)
    res.writeHead(200, {'Content-Type':'application/json'})
    msgInfo.message = "Hi friends"
    res.end(msgInfo.toString())
}

function notFoundUrlCallback(req, res)
{
    saveAddress(req, `${req.url} not found`)
    res.writeHead(404, {'Content-Type':'application/json'})
    msgInfo.message = `${req.url} not found`
    res.end(msgInfo.toString())
}

function serverCallback(req, res)
{
    writeLine(`url:${req.url}`)

    switch (req.url) {
        case '/hello':
            helloUrlCallback(req, res)
            break;
        case '/hello-tr':
            helloTRUrlCallback(req, res)
            break;
        case '/hello-en':
            helloENUrlCallback(req, res)
            break;
        default:
            notFoundUrlCallback(req, res)
    }
}

function main()
{
    const server = http.createServer(serverCallback)
    const port = 50500

    writeLine(`Server is listening on port:${port}`)
    server.listen(port)
}

main()

