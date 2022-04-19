import express from 'express'
import nodeRestClient from 'node-rest-client'
import {sendJSONSuccess, sendJSON400} from '../../../../csd-modules/csdrestutil.mjs'
import {writeLine, writeErrLine} from '../../../../csd-modules/csdstdioutil.mjs'

const url = `http://161.97.141.113:50501/api/postalcodes/postalcode?code=`

/*
Aşağıdakileri programa ekleyiniz:
1. Sorgulanan posta koduna ilişkin bilgileri mongodb'ye kaydediniz. Daha önce eklenmiş olan posta kodu bir daha eklenebilecektir
2. ~/api/postalcode/query?code=67000 şeklinde url'e sahip mongodb'den sorgulama yapan ve tüm code'a ilişkin bilgileri getiren servisi yazınız
*/


function rootUrlCallback(req, res)
{
    sendJSON400(res, JSON.parse('{"message": "Forbidden"}'))
}

function postalCodesUrlCallback(req, res, restClient)
{
    const code = Number(req.query.code)

    restClient.get(`${url}${code}`, data => sendJSONSuccess(res, data))
}


function initService()
{
    const port = Number(process.argv[2])
    const app = express()
    const Client = nodeRestClient.Client
    const restClient = new Client()

    app.get('/', (req, res) => rootUrlCallback(req, res))
    app.get('/api/postalcodes', (req, res) => postalCodesUrlCallback(req, res, restClient))
    writeLine(`Server is listening on port:${port}`)
    app.listen(port);
}


function main()
{
    initService()
}


main()
