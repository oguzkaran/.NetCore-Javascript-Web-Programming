import {MessageInfo} from "./messageinfo.mjs";
import {sendJSONNotFound, sendJSONSuccess} from '../../../csd-modules/csdrestutil.mjs'
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'
import {randomTextEN} from '../../../csd-modules/csdstringutil.mjs'
import {Random} from '../../../csd-modules/csdrandom.mjs'
import {MongoConnection, MongoRepository} from '../../../csd-modules/csdmongodbutil.mjs'
import {remoteAddress} from '../../../csd-modules/csdhttputil.mjs'
import express from 'express'

const msgInfo = new MessageInfo("")
const app = express()

const createRecord = (req, msg) => {return {host: remoteAddress(req), time: new Date().toString(), url: req.url, message: msg}}

function randomTextCallback(mongoRepo, req, res)
{
    const len = req.query.len;

    msgInfo.message =  randomTextEN(len === undefined ? 10 : isNaN(parseInt(len)) ? 1 : len)
    mongoRepo.save(createRecord(req, msgInfo.message))

    sendJSONSuccess(res, msgInfo)
}

function randomNumberCallback(mongoRepo, req, res)
{
    let min = parseInt(req.query.min)
    let max = parseInt(req.query.max)

    if (isNaN(min) || isNaN(max)) {
        min = 0
        max = 99
    }

    msgInfo.message = Random.nextInt(min, max + 1)
    mongoRepo.save(createRecord(req, msgInfo.message))
    sendJSONSuccess(res, msgInfo)
}

function notFoundUrlCallback(mongoRepo, req, res)
{
    msgInfo.message = `${req.url} not found`
    mongoRepo.save(createRecord(req, msgInfo.message))
    sendJSONNotFound(res, msgInfo)
}

function initRepository()
{
    const mongoConn = new MongoConnection(process.argv[3], parseInt(process.argv[4]))

    return new MongoRepository(mongoConn, process.argv[5], process.argv[6])
}

function initService()
{
    const port =  parseInt(process.argv[2])
    const mongoRepo = initRepository();

    writeLine(`Server is listening on port:${port}`)
    app.get('/api/random/text', (req, res) => randomTextCallback(mongoRepo, req, res))
    app.get('/api/random/number', (req, res) => randomNumberCallback(mongoRepo, req, res))
    app.use((req, res) => notFoundUrlCallback(mongoRepo, req, res))
    app.listen(port)
}

export {initService}
