import nodeRestClient from 'node-rest-client'
import {writeErrLine} from '../../../../csd-modules/csdstdioutil.mjs'

process.on("uncaughtException", err => writeErrLine)
const code = Number(process.argv[2])
const url = `http://161.97.141.113:50501/api/postalcodes/postalcode?code=`
const Client = nodeRestClient.Client


function main()
{
    const restClient = new Client()

    restClient.get(`${url}${code}`, (data, res) => console.log(JSON.stringify(data)))
}

main()



