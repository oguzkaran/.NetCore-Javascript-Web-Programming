import {MessageInfo} from "./messageinfo.mjs";
import {saveAddress} from "./crud.mjs";
import {sendJSONNotFound, sendJSONSuccess, sendJSON400} from '../../../csd-modules/csdrestutil.mjs'
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'
import {randomTextEN} from '../../../csd-modules/csdstringutil.mjs'
import {Random} from '../../../csd-modules/csdrandom.mjs'
import express from 'express'

const msgInfo = new MessageInfo("")
const app = express()

function randomTextCallback(req, res)
{
    const len = req.query.len;

    msgInfo.message =  randomTextEN(len === undefined ? 10 : isNaN(parseInt(len)) ? 1 : len)
    saveAddress(req, req.url, msgInfo.message)
    sendJSONSuccess(res, msgInfo)
}

function randomNumberCallback(req, res)
{
    let min = parseInt(req.query.min)
    let max = parseInt(req.query.max)

    if (min === undefined || max === undefined || isNaN(min) || isNaN(max)) {
        min = 0
        max = 99
    }

    msgInfo.message = Random.nextInt(min, max + 1)
    saveAddress(req, req.url, msgInfo.message)
    sendJSONSuccess(res, msgInfo)
}

function notFoundUrlCallback(req, res)
{
    msgInfo.message = `${req.url} not found`
    saveAddress(req, req.url, msgInfo.message)
    sendJSONNotFound(res, msgInfo)
}

function initService()
{
    const port =  parseInt(process.argv[2])

    writeLine(`Server is listening on port:${port}`)
    app.get('/api/random/text', (req, res) => randomTextCallback(req, res))
    app.get('/api/random/number', (req, res) => randomNumberCallback(req, res))
    app.use((req, res) => notFoundUrlCallback(req, res))
    app.listen(port)
}

export {initService}
