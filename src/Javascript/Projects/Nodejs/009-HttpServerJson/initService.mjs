import {MessageInfo} from "./messageinfo.mjs";
import {remoteAddress} from '../../../csd-modules/csdhttputil.mjs'
import {sendJSONNotFound, sendJSONSuccess, sendJSON400} from '../../../csd-modules/csdrestutil.mjs'
import {createMongoClient} from '../../../csd-modules/csdmongodbutil.mjs'
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'
import express from 'express'

const msgInfo = new MessageInfo("")
const app = express()

function connectForInsertCallback(err, client, req, msg)
{
    if (err)
        throw  err

    const db = client.db(process.argv[5])
    const clients = db.collection(process.argv[6])
    const record = {host: remoteAddress(req), time: new Date().toString(), url: msg}
    clients.insertOne(record, err => {if (err) throw err})
}

function saveAddress(req, msg)
{
    const host = process.argv[3]
    const port = parseInt(process.argv[4])
    createMongoClient(host, port).connect((err, client) => connectForInsertCallback(err, client, req, msg))
}

function rootUrlCallback(req, res)
{
    saveAddress(req, req.url)
    msgInfo.message = "Forbidden!..."
    sendJSON400(res, msgInfo)
}

function helloUrlCallback(req, res)
{
    saveAddress(req, req.url)
    msgInfo.message = "Hello!..."
    sendJSONSuccess(res, msgInfo)
}

function helloTRUrlCallback(req, res)
{
    saveAddress(req, req.url)
    msgInfo.message = "Merhaba arkadaşlar"
    sendJSONSuccess(res, msgInfo)
}

function helloENUrlCallback(req, res)
{
    saveAddress(req, req.url)
    msgInfo.message = "Hi friends"
    sendJSONSuccess(res, msgInfo)
}

function notFoundUrlCallback(req, res)
{
    saveAddress(req, `${req.url} not found`)
    msgInfo.message = `${req.url} not found`
    sendJSONNotFound(res, msgInfo)
}

function initService()
{
    const port =  parseInt(process.argv[2])

    writeLine(`Server is listening on port:${port}`)
    app.get('/', (req, res) => rootUrlCallback(req, res))
    app.get('/api/hello', (req, res) => helloUrlCallback(req, res))
    app.get('/api/hello-tr', (req, res) => helloTRUrlCallback(req, res))
    app.get('/api/hello-en', (req, res) => helloENUrlCallback(req, res))
    app.use((req, res) => notFoundUrlCallback(req, res))
    app.listen(port)
}

export {initService}
